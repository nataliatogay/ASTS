using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
    }
}
