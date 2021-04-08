using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tweet_Client
{
    class User
    {
     
            [Required]
            [StringLength(25)]
            public string FirstName { get; set; }

            [StringLength(25)]
            public string Lastname { get; set; }

            [Required]
            [RegularExpression(@"^Male$|^Female$")]
            public string Gender { get; set; }

            [Display(Name = "Date of Birth")]
            //[RegularExpression(@"(d{1,2}/-d{1,2}/-d{2,4})$", ErrorMessage = "Invalid date format.")]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
            public DateTime? Dob { get; set; }

            [Display(Name = "UserName")]
            [Required]
            [StringLength(50)]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(10)]
            public string Password { get; set; }

      
    }
}
