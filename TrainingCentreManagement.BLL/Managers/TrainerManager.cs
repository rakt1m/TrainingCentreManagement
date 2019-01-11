using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class TrainerManager:Manager<Trainer>,ITrainerManager
    {
        public TrainerManager(ITrainerRepository repository) : base(repository)
        {
        }
    }
}
