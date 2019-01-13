using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Scheduls;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
  public  class ScheduleManager:Manager<Schedule>, IScheduleManager
    {
        public ScheduleManager(IScheduleRepository repository) : base(repository)
        {
        }
    }
}
