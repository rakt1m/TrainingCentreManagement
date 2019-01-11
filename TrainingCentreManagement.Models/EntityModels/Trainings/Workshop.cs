using System;
using System.Collections.Generic;
using System.Text;
using TrainingCentreManagement.Models.EntityModels.BaseEntities;
using TrainingCentreManagement.Models.Enums;

namespace TrainingCentreManagement.Models.EntityModels.Trainings
{
    public class Workshop:Training
    {
        public Workshop()
        {
            TrainingTypeId = (long) TrainingTypeEnum.Workshop;
        }

    }
}
