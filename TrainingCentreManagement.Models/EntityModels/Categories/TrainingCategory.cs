using TrainingCentreManagement.Models.EntityModels.Trainings;

namespace TrainingCentreManagement.Models.EntityModels.Categories
{
   public class TrainingCategory
    {
        
        public long CategoryId { get; set; }
        public long TrainingId { get; set; }

        public Training Training { get; set; }
    }
}
