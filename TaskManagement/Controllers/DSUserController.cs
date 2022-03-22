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
    [Route("api/dsuser")]
    [ApiController]
    public class DSUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public DSUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(Guid id)
        {
            ResultModel result;

            result = await _userService.GetUserById(id);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] PagingParam<UserOption> paginationModel)
        {
            ResultModel result;
            result = await _userService.GetUser(paginationModel);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpPost()]
        public async Task<IActionResult> Add(DSUserCreateModel model)
        {
            ResultModel result;

            result = await _userService.AddUser(model);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(DSUserUpdateModel model)
        {
            ResultModel result;

            result = await _userService.Update(model);
            if (result.IsSuccess) return Ok(result.ResponseSuccess);
            return NotFound(result.ResponseFailed);
        }





    }
}
