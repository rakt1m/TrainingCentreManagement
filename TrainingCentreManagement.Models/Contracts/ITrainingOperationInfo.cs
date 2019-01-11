using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingCentreManagement.Models.Contracts
{
    public interface ITrainingOperationInfo
    {
        bool IsFree { get; set; }
        decimal Fee { get; set; }
        int TotalCapacity { get; set; }
         DateTime? RegistrationStart { get; set; }
       
         DateTime? RegistrationEnd { get; set; }
      
         DateTime TrainingStart { get; set; }
    }
}
