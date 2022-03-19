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
    [Route("api/[controller]")]
    [ApiController]
    public class DSMonitorController : ControllerBase
    {
        private readonly IDSMonitorService _monitorService;

        public DSMonitorController(IDSMonitorService monitorService)
        {
            _monitorService = monitorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ResultModel result;

            result = await _monitorService.GetById(id);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpGet("{id}/media")]
        public async Task<IActionResult> GetByIdMedia(Guid id)
        {
            ResultModel result;

            result = await _monitorService.GetMonitorMedia(id);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] PagingParam<DSMonitorOption> paginationModel)
        {
            ResultModel result;

            result = await _monitorService.Get(paginationModel);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }


        [HttpPost()]
        public async Task<IActionResult> Add(DSMonitorCreateModel model)
        {
            ResultModel result;

            result = await _monitorService.Add(model);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }
    }

}
