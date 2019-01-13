using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.EntityModels.Batches;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.Repositories.Repositories
{
    public class BatchTrainerRepository:Repository<BatchTrainer>,IBatchTrainerRepository
    {
    }
}
