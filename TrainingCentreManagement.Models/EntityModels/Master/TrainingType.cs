using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels.Trainings
{
    public class TrainingType:IMasterEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}