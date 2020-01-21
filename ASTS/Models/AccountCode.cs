using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class AccountCode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}
