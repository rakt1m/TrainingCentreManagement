using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels.Master;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class ScedhuleTypeManager:Manager<ScedhuleType>, IScedhuleTypeManager
    {
        public ScedhuleTypeManager(IScedhuleTypeRepository repository) : base(repository)
        {
        }
    }
}
