using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.EntityModels.Trainings;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.Repositories.Repositories
{
   public class TrainingRepository:Repository<Training>,ITrainingRepository
    {
    }
}
