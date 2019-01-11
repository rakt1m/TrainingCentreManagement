using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingCentreManagement.Models.Contracts
{
    public interface IEntity:IAudit,IMasterEntity
    {
       string EntityDescription { get; set; }  

    }
}
