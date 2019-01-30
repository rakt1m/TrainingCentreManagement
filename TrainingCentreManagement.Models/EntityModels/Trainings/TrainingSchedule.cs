using System.ComponentModel.DataAnnotations;
using TrainingCentreManagement.Models.EntityModels.Scheduls;
using TrainingCentreManagement.Models.Enums;

namespace TrainingCentreManagement.Models.EntityModels.Trainings
{
    public  class TrainingSchedule : Schedule
    {
        public TrainingSchedule()
        {
            ScheduleTypeId = (int)ScheduleTypeEnum.Training;
        }

        
        public Training Training { get; set; }
    }
}