using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweet_API.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
