using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.EntityModels.Trainers;
using TrainingCentreManagement.Models.EntityModels.Trainings;

namespace TrainingCentreManagement.Models.EntityModels.Courses
{
    public class TrainingTrainer:TrainerAllocation
    {
        public long TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
