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


        // Materials
        public async Task<ICollection<Material>> GetMaterials()
        {
            return await _db.Materials.ToListAsync();
        }




        // Material requests

        public async Task<MaterialRequest> GetMaterialRequest(int id)
        {
            return await _db.MaterialRequests.FindAsync(id);
        }
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



        // Projects
        public async Task<ICollection<Project>> GetProjects()
        {
            return await _db.Projects.ToListAsync();
        }


        // Areas
        public async Task<ICollection<Area>> GetAreas()
        {
            return await _db.Areas.ToListAsync();
        }


        // Disciplines
        public async Task<ICollection<Discipline>> GetDisciplines()
        {
            return await _db.Disciplines.ToListAsync();
        }


        // Works
        public async Task<ICollection<Work>> GetWorks()
        {
            return await _db.Works.ToListAsync();
        }


        //MaterialGroups
        public async Task<ICollection<MaterialGroup>> GetMaterialGroups()
        {
            return await _db.MaterialGroups.ToListAsync();
        }

        // MaterialUnits

        public async Task<ICollection<MaterialUnit>> GetMaterialUnits()
        {
            return await _db.MaterialUnits.ToListAsync();
        }
    }
}
