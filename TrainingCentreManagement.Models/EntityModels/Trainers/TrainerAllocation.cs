using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels.Trainers
{
    public abstract class TrainerAllocation:IEntity
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public long TrainerAllocationTypeId { get; set; }
        public TrainerAllocationType AllocationType { get; set; }

        public long TrainerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string EntityDescription { get; set; }
    }
}
