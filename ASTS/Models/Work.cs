using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline{ get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}
