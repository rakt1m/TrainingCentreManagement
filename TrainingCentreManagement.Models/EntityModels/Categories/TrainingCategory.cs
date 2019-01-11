using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingCentreManagement.Models.EntityModels.BaseEntities;

namespace TrainingCentreManagement.Models.EntityModels
{
   public class TrainingCategory
    {
        
        public long CategoryId { get; set; }
        public long TrainingId { get; set; }

        public Training Training { get; set; }
    }
}
