using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class MaterialRequest
    {
        public int Id { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime DateRequired { get; set; }
        public string AdditionalInfo { get; set; }
        public int AreaId { get; set; }        
        public int IssuedByUserId { get; set; } 
        public int? DisciplineManagerUserId { get; set; }
        public int? CostControlUserId { get; set; }
        public int? ProjectManagerUserId { get; set; }
        public int? DirectorUserId { get; set; }
        public virtual Area Area { get; set; }
        [ForeignKey("IssuedByUserId")]
        public virtual User IssuedByUser { get; set; }
        [ForeignKey("DisciplineManagerUserId")]
        public virtual User DisciplineManagerUser { get; set; }
        [ForeignKey("CostControlUserId")]
        public virtual User CostControlUser { get; set; }
        [ForeignKey("ProjectManagerUserId")]
        public virtual User ProjectManagerUser { get; set; }
        [ForeignKey("DirectorUserId")]
        public virtual User DirectorUser { get; set; }
        public virtual ICollection<RequestedMaterial> RequestedMaterials { get; set; }
    }

    // status
}
