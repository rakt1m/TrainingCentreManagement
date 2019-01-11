using System.ComponentModel.DataAnnotations;

namespace TrainingCentreManagement.Models
{
   public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
