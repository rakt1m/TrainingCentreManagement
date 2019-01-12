using System.ComponentModel.DataAnnotations;
using TrainingCentreManagement.Models.EntityModels.Scheduls;

namespace TrainingCentreManagement.Models.EntityModels.Batches
{
    public class BatchSchedule : Schedule
    {
        public BatchSchedule()
        {
            ScheduleTypeId = (int) ScheduleTypeEnum.Batch;
        }

        [Required]
        public Batch Batch { get; set; }
    }
}