using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels.Trainers
{
    public class TrainerAllocationType :IMasterEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}