using TrainingCentreManagement.Models.EntityModels.Trainers;

namespace TrainingCentreManagement.Models.EntityModels.Trainings
{
    public class TrainingTrainer:TrainerAllocation
    {
        public long TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
