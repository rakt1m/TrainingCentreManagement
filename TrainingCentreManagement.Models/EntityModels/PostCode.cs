using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.Contracts;

namespace TrainingCentreManagement.Models.EntityModels
{
   public  class PostCode:IEntity    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
   }
}
