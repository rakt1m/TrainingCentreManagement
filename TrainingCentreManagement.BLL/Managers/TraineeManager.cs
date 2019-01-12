using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.Trainees;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
  public class TraineeManager:Manager<Trainee>,ITraineeManager
    {
        public TraineeManager(ITraineeRepository repository) : base(repository)
        {
        }
    }
}
