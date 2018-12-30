using System.ComponentModel.DataAnnotations;

namespace TrainingCentreManagement.Models.EntityModels
{
   public class Institute
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
