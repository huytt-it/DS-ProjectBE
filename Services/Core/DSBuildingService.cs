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
    public interface IDSBuildingService
    {
        Task<ResultModel> GetBuildings(PagingParam<DSBuildingOption> paginationModel);
        Task<ResultModel> GetBuildingById(Guid id);
        Task<ResultModel> Add(DSBuildingCreateModel model);

    }

    public class DSBuildingService: IDSBuildingService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public DSBuildingService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultModel> GetBuildings(PagingParam<DSBuildingOption> paginationModel)
        {
            ResultModel result = new ResultModel();
            try
            {
                var buildings = _context.DSBuilding.Where(c => !c.IsDeleted);

                var paging = new PagingModel(paginationModel.PageIndex, paginationModel.PageSize, buildings.Count());

                buildings = buildings.GetWithSorting(paginationModel.SortKey.ToString(), paginationModel.SortOrder);
                buildings = buildings.GetWithPaging(paginationModel.PageIndex, paginationModel.PageSize);

                var viewModels = await _mapper.ProjectTo<DSBuildingViewModel>(buildings).ToListAsync();
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

        public async Task<ResultModel> GetBuildingById(Guid id)
        {
            ResultModel result = new ResultModel();

            try
            {
                var building = await _context.DSBuilding.FirstOrDefaultAsync(x => x.Id == id);
                if (building == null)
                {
                    throw new Exception(ErrorMessage.ID_NOT_EXIST);
                }

                var data = _mapper.Map<DSBuilding, DSBuildingViewModel>(building);
                result.IsSuccess = true;
                result.ResponseSuccess = data;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> Add(DSBuildingCreateModel model)
        {
            ResultModel result = new ResultModel();

            try
            {
                var data = _mapper.Map<DSBuildingCreateModel, DSBuilding>(model);
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
