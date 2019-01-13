using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Categories;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class TrainingCategoryManager:Manager<TrainingCategory>, ITrainingCategoryManager
    {
        public TrainingCategoryManager(ITrainingCategoryRepository repository) : base(repository)
        {
        }
    }
}
