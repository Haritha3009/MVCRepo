using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvcp1.Models
{
    public class Registration
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string passWord { get; set; }
        [Required]
        public string confirmPassWord { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Phone]
        public string phoneNumber { get; set; }
    }
}