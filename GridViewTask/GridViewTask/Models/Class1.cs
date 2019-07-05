using System.ComponentModel.DataAnnotations;

namespace GridViewTask.Models
{
    public class Class1
    {
        [Required(ErrorMessage ="##")]
        public string Id { set; get; }
    }
}