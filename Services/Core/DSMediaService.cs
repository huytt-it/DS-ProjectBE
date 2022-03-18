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
    public interface IDSMediaService
    {
        Task<ResultModel> Get(PagingParam<DSMediaOption> paginationModel);
        Task<ResultModel> GetById(Guid id);
        Task<ResultModel> Add(DSMediaCreateModel model);

    }


    public class DSMediaService: IDSMediaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public DSMediaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultModel> Get(PagingParam<DSMediaOption> paginationModel)
        {
            ResultModel result = new ResultModel();
            try
            {
                var medias = _context.DSMedia.Where(c => !c.IsDeleted);

                var paging = new PagingModel(paginationModel.PageIndex, paginationModel.PageSize, medias.Count());

                medias = medias.GetWithSorting(paginationModel.SortKey.ToString(), paginationModel.SortOrder);
                medias = medias.GetWithPaging(paginationModel.PageIndex, paginationModel.PageSize);

                var viewModels = await _mapper.ProjectTo<DSMediaViewModel>(medias).ToListAsync();
                paging.Data = viewModels;
                result.IsSuccess = true;
                result.ResponseSuccess = paging;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }

        public async Task<ResultModel> GetById(Guid id)
        {
            ResultModel result = new ResultModel();

            try
            {
                var media = await _context.DSMedia.FirstOrDefaultAsync(x => x.Id == id);
                if (media == null)
                {
                    throw new Exception(ErrorMessage.ID_NOT_EXIST);
                }

                var data = _mapper.Map<DSMedia, DSMediaViewModel>(media);
                result.IsSuccess = true;
                result.ResponseSuccess = data;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> Add(DSMediaCreateModel model)
        {
            ResultModel result = new ResultModel();

            try
            {
                var data = _mapper.Map<DSMediaCreateModel, DSMedia>(model);
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
    }
}
