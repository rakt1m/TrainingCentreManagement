using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace TrainingCentreManagement.Models.EntityModels
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Outline { get; set; }
        [Required]
        [Display(Name="Course Fee")]
        public decimal Fee { get; set; }
        [Required]
        public int Duration { get; set; }
        [Display(Name = "Latest?")]
       
        public bool IsLatest { get; set; }
        [Display(Name = "Upcoming?")]
        
        public bool IsUpComing { get; set; }

        [Display(Name = "On Going")]
     
        public bool IsOnGoing { get; set; }
        [Required]
        public string Tags { get; set; }
       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    
        
    }
}
