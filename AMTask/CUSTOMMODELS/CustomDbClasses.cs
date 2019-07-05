using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOMMODELS
{
    public partial class dbo_t_User_PersonalDetails
    {
        public int UserPersonalId { get; set; }
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }

        public virtual dbo_t_Users dbo_t_Users { get; set; }
    }

    public partial class dbo_t_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbo_t_Users()
        {
            this.dbo_t_User_PersonalDetails = new HashSet<dbo_t_User_PersonalDetails>();
        }

        public int UserId { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbo_t_User_PersonalDetails> dbo_t_User_PersonalDetails { get; set; }
    }
    public class commonFields
    {

    }
    public class modelreg
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
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        // public int Age { get; set; }
    }
    public class modellogin
    {
        public string EMail { get; set; }

        public string Password { get; set; }
    }
}
