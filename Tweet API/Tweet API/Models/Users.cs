using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tweet_API.Models
{
    public partial class Users
    {
        public Users()
        {
            Tweets = new HashSet<Tweets>();
        }

        public int UId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Tweets> Tweets { get; set; }
    }
}
