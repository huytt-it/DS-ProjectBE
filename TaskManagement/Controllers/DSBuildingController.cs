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
    [Route("api/building")]
    [ApiController]
    public class DSBuildingController : ControllerBase
    {
        private readonly IDSBuildingService _buildingService;

        public DSBuildingController(IDSBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ResultModel result;

            result = await _buildingService.GetBuildingById(id);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] PagingParam<DSBuildingOption> paginationModel)
        {
            ResultModel result;

            result = await _buildingService.GetBuildings(paginationModel);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpPost()]
        public async Task<IActionResult> Add(DSBuildingCreateModel model)
        {
            ResultModel result;

            result = await _buildingService.Add(model);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(DSBuildingUpdateModel model)
        {
            ResultModel result;

            result = await _buildingService.Update(model);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ResultModel result;

            result = await _buildingService.Delete(id);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

    }
}
