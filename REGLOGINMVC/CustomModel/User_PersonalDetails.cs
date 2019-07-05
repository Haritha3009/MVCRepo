using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public  class t_User_PersonalDetails
    {
        public int UserPersonalId__UserPersonalId__UserPersonalId { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(6)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FName { get; set; }
        [Required]
        [MaxLength(6)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LName { get; set; }
        [Required]
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
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }

        public virtual t_Users t_Users { get; set; }
    }
}
