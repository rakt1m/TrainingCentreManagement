using System;
using System.ComponentModel.DataAnnotations;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels
{
   public class Trainer:IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string EntityDescription { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name="Linkedin Profile")]
        public string LinkedinProfile { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
