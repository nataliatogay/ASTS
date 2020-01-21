using ASTS.DTOs;
using ASTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Services.Interfaces
{
    public interface IMaterialRequestService
    {
        Task<MaterialRequest> AddNewMaterialRequest(NewMaterialRequestRequest materialRequestRequest, string issuerIdentityId);

        // transfer
        Task<User> AddUser(User user);
    }
}
