using ASTS.DTOs;
using ASTS.EF;
using ASTS.Models;
using ASTS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Services
{
    public class MaterialRequestService : IMaterialRequestService
    {
        private readonly IAsyncRepository _repository;

        public MaterialRequestService(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<MaterialRequest> AddNewMaterialRequest(NewMaterialRequestRequest materialRequestRequest, string issuerIdentityId)
        {
            var issuer = await _repository.GetUser(issuerIdentityId);
            if (issuer is null)
            {
                // issuer not found
                return null;
            }

            // find users by roles (4 types)

            var materialRequest = new MaterialRequest()
            {
                AreaId = materialRequestRequest.AreaId,
                DateIssue = DateTime.ParseExact(materialRequestRequest.DateIssue, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateRequired = DateTime.ParseExact(materialRequestRequest.DateRequired, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                AdditionalInfo = materialRequestRequest.AdditionalInfo,
                //IssuedByUserId = issuer.Id,
                IssuedByUserId = 1

                // continue with users 
            };
            materialRequest = await _repository.AddMaterialRequest(materialRequest);

            foreach (var material in materialRequestRequest.Materials)
            {
                await _repository.AddRequestedMaterial(new Models.RequestedMaterial()
                {
                    MaterialId = material.MaterialId,
                    MaterialRequestId = materialRequest.Id,
                    Quantity = material.Quantity
                });
            }

            return materialRequest;

        }





        // transfer

        public async Task<User> AddUser(User user)
        {
            return await _repository.AddUser(user);
        }
    }
}
