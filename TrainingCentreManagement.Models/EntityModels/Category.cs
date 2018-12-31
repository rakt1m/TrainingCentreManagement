using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingCentreManagement.Models.EntityModels
{
   public class Category
    {
        public int  Id { get; set; }
        public string Name { get; set; }

        public virtual List<Course> Courses { get; set; }
    }
}
