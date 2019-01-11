using System.ComponentModel.DataAnnotations;
using TrainingCentreManagement.Models.EntityModels.BaseEntities;

public  class TrainingSchedule : Schedule
{
    public TrainingSchedule()
    {
        ScheduleTypeId = (int)ScheduleTypeEnum.Training;
    }

    [Required]
   public Training Training { get; set; }
}