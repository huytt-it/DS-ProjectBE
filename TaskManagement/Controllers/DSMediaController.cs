using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Common.PaginationModel;
using Data.Enum;
using Data.ViewModels;
using Services.Core;

namespace TaskManagement.Controllers
{
    [Route("api/media")]
    [ApiController]
    public class DSMediaController : ControllerBase
    {
        private readonly IDSMediaService _dsMediaService;
        public DSMediaController(IDSMediaService dsMediaService)
        {
            _dsMediaService = dsMediaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ResultModel result;

            result = await _dsMediaService.GetById(id);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] PagingParam<DSMediaOption> paginationModel)
        {
            ResultModel result;

            result = await _dsMediaService.Get(paginationModel);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpPost()]
        public async Task<IActionResult> Add(DSMediaCreateModel model)
        {
            ResultModel result;

            result = await _dsMediaService.Add(model);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }
    }
}
