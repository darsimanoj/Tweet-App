using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public int? UId { get; set; }

        [Required]
        [StringLength(25)]
        [RegularExpression(@"[A-Za-z]*$", ErrorMessage = "Firstname must have only Letters")]
        public string FirstName { get; set; }

        [StringLength(25)]
        [RegularExpression(@"[A-Za-z]*$", ErrorMessage = "Lastname must have only Letters")]
        public string Lastname { get; set; }

        [Required]
        [RegularExpression(@"^Male$|^Female$", ErrorMessage = "Please Enter 'Male' or 'Female'.")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter a Valid Date")]
        //[RegularExpression("^([0-9]{1,2})[-]([0-9]{1,2})[-]([0-9]{4,4})$", ErrorMessage = "Invalid date format.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        /*[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]*/
        public DateTime? Dob { get; set; }

        [Display(Name = "UserName")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        public bool LoggedInStatus { get; set; }

        public virtual ICollection<Tweets> Tweets { get; set; }
    }
}
