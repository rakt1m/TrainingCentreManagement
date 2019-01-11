using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels
{
    public class Division:IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string EntityDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
