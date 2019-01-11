using System;
using System.Collections.Generic;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels.Categories
{
   public class Category:IEntity
    {
        public long  Id { get; set; }
        
        public string Name { get; set; }
        public string EntityDescription { get; set; }
        public int? ParentId  { get; set; }
        public Category Parent { get; set; }
        public List<Category> Childs { get; set; } 
        public virtual List<TrainingCategory> Courses { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
