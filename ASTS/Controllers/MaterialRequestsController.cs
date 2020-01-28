using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTS.DTOs;
using ASTS.Models;
using ASTS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASTS.Controllers
{
    public class ResponseTemp
    {
        public string Project { get; set; }
        public string Area { get; set; }
        public string RequiredDate { get; set; }
        public ICollection<MaterialInfoContr> Materials { get; set; }
    }

    public class MaterialInfoContr
    {
        public string Discipline { get; set; }
        public string Work { get; set; }
        public string Group { get; set; }
        public string Material { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class MaterialRequestsController : ResponseController
    {
        private readonly IMaterialRequestService _materialRequestService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;

        public MaterialRequestsController(IMaterialRequestService materialRequestService,
            IEmailService emailService,
            UserManager<IdentityUser> userManager)
        {
            _materialRequestService = materialRequestService;
            _emailService = emailService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse<MaterialRequest>>> Post([FromBody] NewMaterialRequestRequest newMaterialRequest)
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //if (user is null)
            //{
            //    // user not found
            //    return new JsonResult(null);
            //}
            //var res = await _materialRequestService.AddNewMaterialRequest(newMaterialRequest, user.Id);

            var res = await _materialRequestService.AddNewMaterialRequest(newMaterialRequest, "9f4b0e15-7890-4e84-9ba0-223f23ad23fe"); // 83f3b71e-aa2d-4888-8316-26ea3975eca7
            try
            {
                var callbackUrl = Url.Action(
                                    "GetInfo",
                                    "MaterialRequests",
                                    new { requestId = res.Id },
                                    protocol: HttpContext.Request.Scheme);
                string msgBody = $"<a href='{callbackUrl}'>link</a><br> copy to browser: {callbackUrl}";
                await _emailService.SendAsync("nataliatogay@gmail.com", "New material request", msgBody);
                return new JsonResult(Response(Controllers.StatusCode.Ok));
            }
            catch
            {
                return new JsonResult(Response(Controllers.StatusCode.SendingMailError));
            }
            //  return new JsonResult(res);

        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<MaterialRequest>> GetInfo(int requestId)
        {
            MaterialRequest res = await _materialRequestService.GetMaterialRequest(requestId);
            var materials = new List<MaterialInfoContr>();
            foreach (var item in res.RequestedMaterials)
            {
                materials.Add(new MaterialInfoContr()
                {
                    Discipline = item.Material.Work.Discipline.Title,
                    Work = item.Material.Work.Title,
                    Material = item.Material.Title,
                    Group = item.Material.MaterialGroup.Title,
                    Quantity = item.Quantity,
                    Unit = item.Material.MaterialUnit.Title
                });
            }
            var result = new ResponseTemp()
            {
                Project = res.Area.Project.Title,
                Area = res.Area.Title,
                RequiredDate = res.DateRequired.ToShortDateString(),
                Materials = materials
            };

            var res2 = new JsonResult(res);
            return res2;
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

            var newUser = await _materialRequestService.AddUser(new User()
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