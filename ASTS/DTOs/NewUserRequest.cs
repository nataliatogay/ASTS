using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.DTOs
{
    public class NewUserRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Abbreviation { get; set; }
        public int DisciplineId { get; set; }
        public int MyProperty { get; set; }
        public int PositionId { get; set; }
    }
}
