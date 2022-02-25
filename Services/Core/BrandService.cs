using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Constant;
using Data.DataAccess;
using Data.Models;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Services.Core
{
    public interface IBrandService
    {
        Task<ResultModel> AddBrand(BrandCreateModel model);
        Task<ResultModel> GetBrandById(int id);
        Task<ResultModel> UpdateBrand(BrandUpdateModel model);
        Task<ResultModel> DeleteBrand(int id);
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

        public async Task<ResultModel> GetBrandById(int id)
        {
            ResultModel result = new ResultModel();

            try
            {
                var brand =  await _context.Brand.FirstOrDefaultAsync(x => x.BrandId == id);
                if (brand == null)
                {
                    throw new Exception(ErrorMessage.ID_NOT_EXIST);
                }

                var data = _mapper.Map<Brand, BrandViewModel>(brand);
                result.IsSuccess = true;
                result.ResponseSuccess = data;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
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


        public async Task<ResultModel> UpdateBrand(BrandUpdateModel model)
        {
            ResultModel result = new ResultModel();

            try
            {
                var brand = await _context.Brand.FirstOrDefaultAsync(x => x.BrandId == model.BrandId);
                if (brand == null)
                {
                    throw new Exception(ErrorMessage.ID_NOT_EXIST);
                }

                brand = _mapper.Map(model, brand);
                _context.Update(brand);
                _context.SaveChanges();
                result.IsSuccess = true;
                result.ResponseSuccess = brand.BrandId;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }

        public async Task<ResultModel> DeleteBrand(int id)
        {
            ResultModel result = new ResultModel();

            try
            {
                var brand = await _context.Brand.FirstOrDefaultAsync(x => x.BrandId == id);
                if (brand == null)
                {
                    throw new Exception(ErrorMessage.ID_NOT_EXIST);
                }

                brand.IsDelete = true;
                _context.Update(brand);
                _context.SaveChanges();
                result.IsSuccess = true;
                result.ResponseSuccess = brand.BrandId;
            }
            catch (Exception e)
            {
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }

            return result;
        }


    }
}
