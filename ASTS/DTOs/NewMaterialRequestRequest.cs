using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.DTOs
{
    public class NewMaterialRequestRequest
    {

        [Required]
        public DateTime DateRequired { get; set; }
        public int AreaId { get; set; }
        public string AdditionalInfo { get; set; }
        public ICollection<RequestedMaterialRequest> Materials { get; set; }
    }
    public class RequestedMaterialRequest
    {
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
    }
}
