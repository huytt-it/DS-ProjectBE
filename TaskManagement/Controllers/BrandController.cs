using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.ViewModels;
using Services.Core;

namespace TaskManagement.Controllers
{
    [Route("api/v1/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandCreateModel model)
        {
            ResultModel result;

            result = await _brandService.AddBrand(model);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }
    }
}
