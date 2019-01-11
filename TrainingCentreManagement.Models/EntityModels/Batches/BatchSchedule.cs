using System.ComponentModel.DataAnnotations;
using TrainingCentreManagement.Models.EntityModels;

public class BatchSchedule : Schedule
{
    public BatchSchedule()
    {
        ScheduleTypeId = (int) ScheduleTypeEnum.Batch;
    }

    [Required]
    public Batch Batch { get; set; }
}