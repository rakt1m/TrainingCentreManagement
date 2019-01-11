using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingCentreManagement.Models.EntityModels
{
    public class CourseTag
    {
        [Key]

        public int CourseId { get; set; }
        [Key]
        public int TagId { get; set; }

        public Tag Tag { get; set; }
        public Course Course { get; set; }


    }
}
