using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TrainingCentreManagement.Models.EntityModels.BaseEntities;

namespace TrainingCentreManagement.Models.EntityModels
{
    public class TrainingTag
    {
       
        public long TrainingId { get; set; }
     
        public long TagId { get; set; }

        public Tag Tag { get; set; }
        public Training Training { get; set; }


    }
}
