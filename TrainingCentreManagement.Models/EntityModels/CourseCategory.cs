using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingCentreManagement.Models.EntityModels
{
   public class CourseCategory
    {
        [Key]
        [Column(Order = 0)]
        public int CategoryId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }

    }
}
