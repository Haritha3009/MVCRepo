using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class t_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Users()
        {
            this.t_User_PersonalDetails = new HashSet<t_User_PersonalDetails>();
        }

        public int UserId { get; set; }
        [Required]
        [EmailAddress]
       // [MaxLength(8)]
        public string EMail { get; set; }
        [Required]
        [MaxLength(8)]
        [RegularExpression("^[ A-Za-z0-9_@./#&+-]*$")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_User_PersonalDetails> t_User_PersonalDetails { get; set; }
    }
}
