using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMTask.Models
{
    public class mvcmodelreg
    {
            // public int UserPersonalId { get; set; }

            // public int UserId { get; set; }
            [Required]
            [EmailAddress]
            public string EMail { get; set; }
            [Required]
            public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LName { get; set; }
        [MaxLength(10)]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                           ErrorMessage = "Entered phone format is not valid.")]

        public string Phone { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public System.DateTime DOB { get; set; }
        [Required]
        public string Address { get; set; }

            // public int Age { get; set; }
        
    }
    public class mvcregisValid
    {
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}