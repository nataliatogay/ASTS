using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class RequestedMaterial
    {
        public int Id { get; set; }
        public int MaterialRequestId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
        public virtual MaterialRequest MaterialRequest { get; set; }
        public virtual Material Material { get; set; }
    }

    // companyId
    //price
    
}
