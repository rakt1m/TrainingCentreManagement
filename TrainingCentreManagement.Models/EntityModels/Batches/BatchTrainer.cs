using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TrainingCentreManagement.Models.EntityModels.Trainers;

namespace TrainingCentreManagement.Models.EntityModels.Batches
{
    public class BatchTrainer : TrainerAllocation
    {
        public long BatchId { get; set; }

        public Batch Batch { get; set; }
        public Trainer Trainer { get; set; }

    }
}
