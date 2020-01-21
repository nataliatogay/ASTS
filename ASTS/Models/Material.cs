using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WorkId { get; set; }
        public int MaterialUnitId { get; set; }
        public int AccountCodeId { get; set; }
        public int MaterialGroupId { get; set; }
        public virtual Work Work { get; set; }
        public virtual MaterialUnit MaterialUnit { get; set; }
        public virtual AccountCode AccountCode { get; set; }
        public virtual MaterialGroup MaterialGroup { get; set; }
        public virtual ICollection<RequestedMaterial> RequestedMaterials { get; set; }
    }
}
