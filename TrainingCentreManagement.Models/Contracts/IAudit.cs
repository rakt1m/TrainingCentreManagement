using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace TrainingCentreManagement.Models.Contracts
{
    public interface IAudit
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
