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

       [DefaultValue(1)]
        public int IsLatest { get; set; }

        [DefaultValue(0)]
        public int IsUpComing { get; set; }

        [DefaultValue(0)]

        public int IsOnGoing { get; set; }
        
        public string Tags { get; set; }
             
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Batch> Batches { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
