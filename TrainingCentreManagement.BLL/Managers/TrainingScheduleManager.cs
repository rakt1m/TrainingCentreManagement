using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Trainings;
using TrainingCentreManagement.Repositories.Contracts;
using TrainingCentreManagement.Repositories.Repositories;

namespace TrainingCentreManagement.BLL.Managers
{
    public class TrainingScheduleManager :Manager<TrainingSchedule>,ITrainingScheduleManager
    {
        public TrainingScheduleManager(ITrainingScheduleRepository repository) : base(repository)
        {
        }
    }
}
