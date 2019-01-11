using System;
using System.Collections.Generic;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels.Tags
{
    public class Tag:IEntity
    {
     
        public long Id { get; set; }
        public string Name { get; set; }
        public string EntityDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<TrainingTag> Trainings { get; set; }
    }
}
