using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Common.PaginationModel;
using Data.Constant;
using Data.DataAccess;
using Data.Enum;
using Data.Models;
using Data.Utility.Paging;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Services.Core
{

    public interface IUserService
    {
        Task<ResultModel> GetUser(PagingParam<UserOption> paginationModel);
        Task<ResultModel> AddUser(DSUserCreateModel model);
        Task<ResultModel> GetUserById(Guid id);
        Task<ResultModel> Update(DSUserUpdateModel model);
    }


    public class UserService:IUserService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultModel> GetUser(PagingParam<UserOption> paginationModel)
        {
            ResultModel result = new ResultModel();
            try
            {
                var users = _context.DSUser.Where(c => !c.IsDeleted);

                var paging = new PagingModel(paginationModel.PageIndex, paginationModel.PageSize, users.Count());

                users = users.GetWithSorting(paginationModel.SortKey.ToString(), paginationModel.SortOrder);
                users = users.GetWithPaging(paginationModel.PageIndex, paginationModel.PageSize);

                var viewModels = await _mapper.ProjectTo<DSUserViewModel>(users).ToListAsync();
                paging.Data = viewModels;
                result.IsSuccess = true;
                result.ResponseSuccess = viewModels;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }

        public async Task<ResultModel> AddUser(DSUserCreateModel model)
        {
            ResultModel result = new ResultModel();

            try
            {
                var data = _mapper.Map<DSUserCreateModel, DSUser>(model);
                _context.Add(data);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.ResponseSuccess = data.Id;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> GetUserById(Guid id)
        {
            ResultModel result = new ResultModel();

            try
            {
                var brand = await _context.DSUser.FirstOrDefaultAsync(x => x.Id == id);
                if (brand == null)
                {
                    throw new Exception(ErrorMessage.ID_NOT_EXIST);
                }

                var data = _mapper.Map<DSUser, DSUserViewModel>(brand);
                result.IsSuccess = true;
                result.ResponseSuccess = data;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> Update(DSUserUpdateModel model)
        {
            ResultModel result = new ResultModel();
            var user = await _context.DSUser.Where(r => r.Id == model.Id && !r.IsDeleted).FirstOrDefaultAsync();
            if (user == null)
            {
                result.IsSuccess = false;
                result.ResponseFailed = ErrorMessage.ID_NOT_EXIST;
                return result;
            }
            try
            {
                user = _mapper.Map(model, user);
                user.DateUpdated = DateTime.Now;
                _context.Update(user);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.ResponseSuccess = _mapper.Map<DSUser, DSUserViewModel>(user);
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }
    }
}
