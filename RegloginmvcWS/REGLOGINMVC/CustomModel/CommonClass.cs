using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
     public class CommonClass
    {
        
        public int UserPersonalId { get; set; }

       // public int UserId { get; set; }
        public string EMail { get; set; }
       
        public string Password { get; set; }
      
        public string FName { get; set; }
      
        public string LName { get; set; }
      
     
        public string Phone { get; set; }
       
        public bool Gender { get; set; }
       
        public System.DateTime DOB { get; set; }
    
        public string Address { get; set; }

        public int Age { get; set; }
    }
    public class CommonClass1
    {
        [Key]
        public int UserPersonalId { get; set; }

        public string EMail { get; set; }

        public string Phone { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }


        public int Age { get; set; }
        public bool Gender { get; set; }

        public Nullable<System.DateTime> DOB { get; set; }


    }
}
