using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Trainings;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class TrainingManager:Manager<Training>, ITrainingManager
    {
        public TrainingManager(ITrainingRepository repository) : base(repository)
        {
        }
    }
}
