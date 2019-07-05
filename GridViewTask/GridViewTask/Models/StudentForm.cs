using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GridViewTask.Models
{
    public class StudentForm
    {
[Required]
        public int StudentId { get; set; }
      [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public bool ScholarshipApplicable { get; set; }


    }
   
}