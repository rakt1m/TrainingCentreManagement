using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Tags;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
  public  class TrainingTagManager:Manager<TrainingTag>, ITrainingTagManager
    {
        public TrainingTagManager(ITrainingTagRepository repository) : base(repository)
        {
        }
    }
}
