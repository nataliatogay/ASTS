using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTS.DTOs;
using ASTS.Models;
using ASTS.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASTS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MaterialRequestsController : ControllerBase
    {
        private readonly IMaterialRequestService _materialRequestService;
        private readonly UserManager<IdentityUser> _userManager;

        public MaterialRequestsController(IMaterialRequestService materialRequestService,
            UserManager<IdentityUser> userManager)
        {
            _materialRequestService = materialRequestService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<MaterialRequest>> Post([FromBody] NewMaterialRequestRequest newMaterialRequest)
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //if (user is null)
            //{
            //    // user not found
            //    return new JsonResult(null);
            //}
            //var res = await _materialRequestService.AddNewMaterialRequest(newMaterialRequest, user.Id);

            var res = await _materialRequestService.AddNewMaterialRequest(newMaterialRequest, "83f3b71e-aa2d-4888-8316-26ea3975eca7"); // 83f3b71e-aa2d-4888-8316-26ea3975eca7
            return new JsonResult(res);

        }


        // transfer

        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> AddUser([FromBody] string email)
        {
            var identityUser = await _userManager.FindByNameAsync(email);
            if (identityUser is null)
            {
                var res = await _userManager.CreateAsync(new IdentityUser()
                {
                    Email = email,
                    UserName = email
                }, "admin");

                if (res.Succeeded)
                {
                    identityUser = await _userManager.FindByNameAsync(email);
                }
            }
            // add new user

            var newUser = _materialRequestService.AddUser(new User()
            {
                FirstName = "Erman",
                LastName = "Togay",
                DisciplineId = 1,
                Abbreviation = "PM",
                IdentityUserId = identityUser.Id,
                PositionId = 2
            });

            return new JsonResult(newUser);


        }

    }
}