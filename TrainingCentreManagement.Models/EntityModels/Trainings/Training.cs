using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainingCentreManagement.Models.Contracts;
using TrainingCentreManagement.Models.EntityModels.Batches;
using TrainingCentreManagement.Models.EntityModels.Categories;
using TrainingCentreManagement.Models.EntityModels.Master;
using TrainingCentreManagement.Models.EntityModels.Tags;

namespace TrainingCentreManagement.Models.EntityModels.Trainings
{
    public abstract class Training:IEntity,ITrainingOperationInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string EntityDescription { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Outline { get; set; }
        [Required]
        public long TrainingTypeId { get; set; }
        public TrainingType TrainingType { get; set; }

        public List<TrainingTag> Tags { get; set; }
        public List<TrainingCategory> Categories { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public bool HasBatches { get; set; }
        public virtual List<Batch> Batches { get; set; }
        public bool IsFree { get; set; }
        [Required]
        [Display(Name = "Course Fee")]
        public decimal Fee { get; set; }

        public long? TrainingScheduleId { get; set; }

        public TrainingSchedule TrainingSchedule { get; set; }                 
                    
              
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TotalCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? RegistrationStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? RegistrationEnd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime TrainingStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    
}