using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
