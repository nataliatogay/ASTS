using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASTS.DTOs;
using Newtonsoft.Json;

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
            var res = new JsonResult(Response(await _parametersRequestService.GetParameters()));
            return res;
        }


        //[HttpGet]
        //public async Task<ActionResult<string>> Get()
        //{
        //    var res = JsonConvert.SerializeObject(Response(await _parametersRequestService.GetParameters()));
        //    //var jres = new JsonResult(res);
        //    return res;
        //}
    }
}