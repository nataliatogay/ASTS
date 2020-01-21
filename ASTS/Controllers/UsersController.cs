using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTS.DTOs;
using ASTS.Models;
using ASTS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(IUserService userService, UserManager<IdentityUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] NewUserRequest newUserRequest)
        {
            var identityUser = await _userManager.FindByNameAsync(newUserRequest.Email);
            if (identityUser != null)
            {
                // email is already used
                return new JsonResult(null);
            }
            var password = _userService.GeneratePassword();
            var res = await _userManager.CreateAsync(new IdentityUser()
            {
                Email = newUserRequest.Email,
                UserName = newUserRequest.Email
            }, password);

            if (res.Succeeded)
            {
                identityUser = await _userManager.FindByNameAsync(newUserRequest.Email);
                return new JsonResult(await _userService.AddNewUser(newUserRequest, identityUser.Id));
            }
            else
            {
                // cannot create user
                return new JsonResult(null);
            }
        }
    }
}