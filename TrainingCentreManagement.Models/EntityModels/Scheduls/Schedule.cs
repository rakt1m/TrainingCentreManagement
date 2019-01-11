using System;
using System.Collections.Generic;
using TrainingCentreManagement.Models.Contracts;

public abstract class Schedule:IEntity
{

    public long Id { get; set; }
    public string Name { get; set; }
    
    public string EntityDescription { get; set; }
    public double TotalHours { get; set; }
    public int TotalSessions { get; set; }
    public long ScheduleTypeId { get; set; }
    public ScedhuleType ScedhuleType { get; set; }

    public List<ScheduleDetail> ScheduleDetails { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
   
}