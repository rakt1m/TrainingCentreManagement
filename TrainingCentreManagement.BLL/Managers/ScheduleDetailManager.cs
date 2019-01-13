using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Scheduls;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class ScheduleDetailManager:Manager<ScheduleDetail>, IScheduleDetailManager
    {
        public ScheduleDetailManager(IScheduleDetailRepository repository) : base(repository)
        {
        }
    }
}
