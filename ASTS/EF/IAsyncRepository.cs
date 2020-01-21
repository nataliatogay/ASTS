using ASTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.EF
{
    public interface IAsyncRepository
    {
        // Users
        Task<User> GetUser(string identityId);
        Task<User> AddUser(User user);

        // Material requests
        Task<MaterialRequest> AddMaterialRequest(MaterialRequest materialRequest);
        Task<RequestedMaterial> AddRequestedMaterial(RequestedMaterial requestedMaterial);
    }
}
