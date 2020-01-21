using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class MaterialUnit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}
