using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Master;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class TrainingTypeManager:Manager<TrainingType>, ITrainingTypeManager
    {
        public TrainingTypeManager(ITrainingTypeRepository repository) : base(repository)
        {
        }
    }
}
