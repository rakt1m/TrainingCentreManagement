using TrainingCentreManagement.Models.EntityModels.Trainings;

namespace TrainingCentreManagement.Models.EntityModels.Tags
{
    public class TrainingTag
    {
       
        public long TrainingId { get; set; }
     
        public long TagId { get; set; }

        public Tag Tag { get; set; }
        public Training Training { get; set; }


    }
}
