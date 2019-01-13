using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Trainers;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class TrainerAllocationTypeManager:Manager<TrainerAllocationType>, ITrainerAllocationTypeManager
    {
        public TrainerAllocationTypeManager(ITrainerAllocationTypeRepository repository) : base(repository)
        {
        }
    }
}
