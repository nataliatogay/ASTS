using System.Collections.Generic;

namespace ASTS.DTOs
{
    public class MaterialRequestParametersResponse
    {
        public ICollection<ProjectInfo> Projects { get; set; }
        public ICollection<AreaInfo> Areas { get; set; }
        public ICollection<DiscipineInfo> Disciplines { get; set; }
        public ICollection<WorkInfo> Works { get; set; }
        public ICollection<MaterialGroupInfo> MaterialGroups { get; set; }
        public ICollection<MaterialUnitInfo> MaterialUnits { get; set; }
        public ICollection<MaterialInfo> Materials { get; set; }
    }


    public class ProjectInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }

    public class AreaInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int ProjectId { get; set; }
    }

    public class DiscipineInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class WorkInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DisciplineId { get; set; }
    }

    public class MaterialGroupInfo {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class MaterialUnitInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class MaterialInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaterialGroupId { get; set; }
        public int WorkId { get; set; }
        public int MaterialUnitId { get; set; }
    }
}
