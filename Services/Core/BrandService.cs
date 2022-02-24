using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataAccess;
using Data.Models;
using Data.ViewModels;

namespace Services.Core
{
    public interface IBrandService
    {
        Task<ResultModel> AddBrand(BrandCreateModel model);
    }
    public class BrandService: IBrandService
    {
        private AppDbContext _context;
        private IMapper _mapper;


        public BrandService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultModel> AddBrand(BrandCreateModel model)
        {
            ResultModel result = new ResultModel();

            try
            {
                var data = _mapper.Map<BrandCreateModel, Brand>(model);
                _context.Add(data);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.ResponseSuccess = data.BrandId;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }
    }
}
