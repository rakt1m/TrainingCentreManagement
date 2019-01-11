using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingCentreManagement.Models.Contracts
{
    public interface IEntity:IAudit
    {
        int Id { get; set; }
        string Name { get; set; }
        string EntityDescription { get; set; }  

    }
}
