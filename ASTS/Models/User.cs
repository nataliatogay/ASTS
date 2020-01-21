using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Abbreviation { get; set; }
        public int DisciplineId { get; set; }
        public int PositionId { get; set; }
        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<MaterialRequest> MaterialRequestsIssued { get; set; }
        public virtual ICollection<MaterialRequest> MaterialRequestsDiscManager { get; set; }
        public virtual ICollection<MaterialRequest> MaterialRequestsCostControl { get; set; }
        public virtual ICollection<MaterialRequest> MaterialRequestsProjectManager { get; set; }
        public virtual ICollection<MaterialRequest> MaterialRequestsDirector { get; set; }
    }
}
