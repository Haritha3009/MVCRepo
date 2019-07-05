using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REGLOGINMVC.Models
{
    public class ViewModel
    {
        public t_User_PersonalDetails userPersonal {get;set;}
        public t_Users user { get; set; }
    }
    public class CustomView
    {

        public int UserPersonalId { get; set; }

        public int ModifiedBy { get; set; }

        public int UserId { get; set; }

        public string EMail { get; set; }

        public string Password { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Phone { get; set; }

        public bool Gender { get; set; }

        public int Age { get; set; }

        public string Adderss { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> LastUpdatedDate { get; set; }

        //public t_Users AddUser { get; set; }
        //public t_User_PersonalDetails AddUserDt { get; set; }
    }
}