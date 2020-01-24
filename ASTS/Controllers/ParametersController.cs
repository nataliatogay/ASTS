using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASTS.DTOs;

namespace ASTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ResponseController
    {
        private readonly IParametersService _parametersRequestService;

        public ParametersController(IParametersService parametersRequestService)
        {
            _parametersRequestService = parametersRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<ServerResponse<MaterialRequestParametersResponse>>> Get()
        {
            return new JsonResult(Response(await _parametersRequestService.GetParameters()));
        }
    }
}