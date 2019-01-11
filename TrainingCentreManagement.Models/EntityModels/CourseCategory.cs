using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingCentreManagement.Models.EntityModels
{
   public class CourseCategory
    {
        
        public int CategoryId { get; set; }
        public int CourseId { get; set; }

    }
}
