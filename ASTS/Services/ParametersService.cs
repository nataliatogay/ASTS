using ASTS.DTOs;
using ASTS.EF;
using ASTS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Services
{
    public class ParametersService : IParametersService
    {
        private readonly IAsyncRepository _repository;

        public ParametersService(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<MaterialRequestParametersResponse> GetParameters()
        {
            var projects = await _repository.GetProjects();
            var areas = await _repository.GetAreas();
            var disciplines = await _repository.GetDisciplines();
            var works = await _repository.GetWorks();
            var materialGroups = await _repository.GetMaterialGroups();
            var materialUnits = await _repository.GetMaterialUnits();
            var materials = await _repository.GetMaterials();

            var projectInfo = new List<ProjectInfo>();
            if (projects != null)
            {
                foreach (var pr in projects)
                {
                    projectInfo.Add(new ProjectInfo()
                    {
                        Id = pr.Id,
                        Title = pr.Title,
                        Code = pr.Code
                    });
                }
            }

            var areasInfo = new List<AreaInfo>();
            if (areas != null)
            {
                foreach (var a in areas)
                {
                    areasInfo.Add(new AreaInfo()
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Code = a.Code,
                        ProjectId = a.ProjectId
                    });
                }
            }

            var disciplineInfo = new List<DiscipineInfo>();
            if (disciplines != null)
            {
                foreach (var d in disciplines)
                {
                    disciplineInfo.Add(new DiscipineInfo()
                    {
                        Id = d.Id,
                        Title = d.Title
                    });
                }
            }

            var workInfo = new List<WorkInfo>();
            if(works!= null)
            {
                foreach (var w in works)
                {
                    workInfo.Add(new WorkInfo()
                    {
                        Id = w.Id,
                        Title = w.Title,
                        DisciplineId = w.DisciplineId
                    });
                }
            }

            var materialGroupInfo = new List<MaterialGroupInfo>();
            if(materialGroups != null)
            {
                foreach (var gr in materialGroups)
                {
                    materialGroupInfo.Add(new MaterialGroupInfo()
                    {
                        Id = gr.Id,
                        Title = gr.Title
                    });
                }
            }

            var materialUnitInfo = new List<MaterialUnitInfo>();
            if(materialUnits != null)
            {
                foreach (var u in materialUnits) 
                {
                    materialUnitInfo.Add(new MaterialUnitInfo()
                    {
                        Id = u.Id,
                        Title = u.Title
                    });
                }
            }

            var materialInfo = new List<MaterialInfo>();
            foreach (var m in materials)
            {
                materialInfo.Add(new MaterialInfo()
                {
                    Id = m.Id,
                    Title = m.Title,
                    WorkId = m.WorkId,
                    MaterialGroupId = m.MaterialGroupId,
                    MaterialUnitId = m.MaterialUnitId
                });
            }

            return new MaterialRequestParametersResponse()
            {
                Projects = projectInfo,
                Areas = areasInfo,
                Disciplines = disciplineInfo,
                Works = workInfo,
                MaterialGroups = materialGroupInfo,
                MaterialUnits = materialUnitInfo,
                Materials = materialInfo
            };
        }
    }
}
