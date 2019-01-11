using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels
{
    public class Course:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EntityDescription { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Outline { get; set; }
        [Required]
        [Display(Name="Course Fee")]
        public decimal Fee { get; set; }
        [Required]
        public int Duration { get; set; }
        public List<CourseTag> Tags { get; set; }
             
        public List<CourseCategory> Categories { get; set; }

        public virtual List<Batch> Batches { get; set; }

        public  string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool IsActive { get; set; }  

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
