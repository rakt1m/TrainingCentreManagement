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
<<<<<<< HEAD
       [DefaultValue(1)]
        public int IsLatest { get; set; }

        [DefaultValue(0)]
        public int IsUpComing { get; set; }

        [DefaultValue(0)]

        public int IsOnGoing { get; set; }
        [Required]
        public string Tags { get; set; }
       
        public int CategoryId { get; set; } 
=======
        [Display(Name = "Latest?")]
       
        public bool IsLatest { get; set; }
        [Display(Name = "Upcoming?")]
        
        public bool IsUpComing { get; set; }

        [Display(Name = "On Going")]
     
        public bool IsOnGoing { get; set; }
        [Required]
        public string Tags { get; set; }
       
        public int CategoryId { get; set; }
>>>>>>> f086ee706453272d91887f09ef1c2e4ebf3d9e98
        public virtual Category Category { get; set; }

    
        
    }
}
