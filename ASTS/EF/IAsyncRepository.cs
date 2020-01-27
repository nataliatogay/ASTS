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


        // Materials
        Task<ICollection<Material>> GetMaterials();



        // Material requests
        Task<MaterialRequest> GetMaterialRequest(int id);
        Task<MaterialRequest> AddMaterialRequest(MaterialRequest materialRequest);
        Task<RequestedMaterial> AddRequestedMaterial(RequestedMaterial requestedMaterial);





        // Projects
        Task<ICollection<Project>> GetProjects();


        // Areas
        Task<ICollection<Area>> GetAreas();


        // Disciplines
        Task<ICollection<Discipline>> GetDisciplines();


        // Works
        Task<ICollection<Work>> GetWorks();


        //MaterialGroups
        Task<ICollection<MaterialGroup>> GetMaterialGroups();

        // MaterialUnits

        Task<ICollection<MaterialUnit>> GetMaterialUnits();


        
    }
}
