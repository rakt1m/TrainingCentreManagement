using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.EntityModels.BaseEntities;
using TrainingCentreManagement.Models.EntityModels.Trainers;

namespace TrainingCentreManagement.Models.EntityModels.Courses
{
    public class TrainingTrainer:TrainerAllocation
    {
        public long TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
