using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainingCentreManagement.Models.Contracts;
using TrainingCentreManagement.Models.EntityModels.BaseEntities;
using TrainingCentreManagement.Models.EntityModels.Batches;
using TrainingCentreManagement.Models.EntityModels.Courses;

namespace TrainingCentreManagement.Models.EntityModels
{
    public class Batch : IEntity, ITrainingOperationInfo
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string EntityDescription { get; set; }
        public string Description { get; set; }

        [Required]
        public int TotalCapacity { get; set; }

        public DateTime? RegistrationStart { get; set; }

        public DateTime? RegistrationEnd { get; set; }

        public DateTime TrainingStart { get; set; }
        
        public long? BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }
        public long TrainingId { get; set; }
        public virtual Training Training { get; set; }

        public ICollection<BatchTrainer> BatchTrainers { get; set; }

        public bool IsFree { get; set; }

        [Required]
        public decimal Fee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
