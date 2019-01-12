using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.Trainees;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.Repositories.Repositories
{
   public class TraineeRepository:Repository<Trainee>,ITraineeRepository
    {
    }
}
