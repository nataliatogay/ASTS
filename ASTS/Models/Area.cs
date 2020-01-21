using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project{ get; set; }
        public virtual ICollection<MaterialRequest> MaterialRequests { get; set; }
    }
}
