using System;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels.Location
{
    public class District:IEntity

    {
     
        public long Id { get; set; }
        public string Name { get; set; }
        public string EntityDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
