using ASTS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.EF
{
    public class EfAsyncRepository : IAsyncRepository
    {
        private readonly AstsDbContext _db;

        public EfAsyncRepository(AstsDbContext db)
        {
            _db = db;
        }

        // Users

        public async Task<User> GetUser(string identityId)
        {
            return await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.IdentityUserId.Equals(identityId));
        }

        public async Task<User> AddUser(User user)
        {
            var res = _db.ApplicationUsers.Add(user);
            await _db.SaveChangesAsync();
            return res.Entity;
        }



        // Material requests
        public async Task<MaterialRequest> AddMaterialRequest(MaterialRequest materialRequest)
        {
            var res = _db.MaterialRequests.Add(materialRequest);
            await _db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<RequestedMaterial> AddRequestedMaterial(RequestedMaterial requestedMaterial)
        {
            var res = _db.RequestedMaterials.Add(requestedMaterial);
            await _db.SaveChangesAsync();
            return res.Entity;
        }
    }
}
