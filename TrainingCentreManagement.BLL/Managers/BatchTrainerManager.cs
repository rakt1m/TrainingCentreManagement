using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Batches;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class BatchTrainerManager:Manager<BatchTrainer>,IBatchTrainerManager
    {
        public BatchTrainerManager(IBatchTrainerRepository repository) : base(repository)
        {
        }
    }
}
