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

    public interface IDSMonitorService
    {
        Task<ResultModel> Get(PagingParam<DSMonitorOption> paginationModel);
        Task<ResultModel> GetById(Guid id);
        Task<ResultModel> Add(DSMonitorCreateModel model);

    }
    public class DSMonitorService: IDSMonitorService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public DSMonitorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultModel> Get(PagingParam<DSMonitorOption> paginationModel)
        {
            ResultModel result = new ResultModel();
            try
            {
                var monitors = _context.DSMonitor.Where(c => !c.IsDeleted);

                var paging = new PagingModel(paginationModel.PageIndex, paginationModel.PageSize, monitors.Count());

                monitors = monitors.GetWithSorting(paginationModel.SortKey.ToString(), paginationModel.SortOrder);
                monitors = monitors.GetWithPaging(paginationModel.PageIndex, paginationModel.PageSize);

                var viewModels = await _mapper.ProjectTo<DSMonitorViewModel>(monitors).ToListAsync();
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
                var monitor = await _context.DSMonitor.FirstOrDefaultAsync(x => x.Id == id);
                if (monitor == null)
                {
                    throw new Exception(ErrorMessage.ID_NOT_EXIST);
                }

                var data = _mapper.Map<DSMonitor, DSMonitorViewModel>(monitor);
                result.IsSuccess = true;
                result.ResponseSuccess = data;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> Add(DSMonitorCreateModel model)
        {
            ResultModel result = new ResultModel();

            try
            {
                var data = _mapper.Map<DSMonitorCreateModel, DSMonitor>(model);
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
