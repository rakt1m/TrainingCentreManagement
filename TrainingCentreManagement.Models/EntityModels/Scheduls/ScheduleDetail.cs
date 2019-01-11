using System;
using TrainingCentreManagement.Models.Contracts;

public class ScheduleDetail:IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string EntityDescription { get; set; }

    public long ScheduleId { get; set; }
    public Schedule TrainingSchedule { get; set; }

    public int? Day { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime? Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  
}