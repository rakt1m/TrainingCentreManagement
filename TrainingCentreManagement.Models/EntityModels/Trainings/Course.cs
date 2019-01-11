using TrainingCentreManagement.Models.EntityModels.BaseEntities;
using TrainingCentreManagement.Models.Enums;

namespace TrainingCentreManagement.Models.EntityModels.Trainings
{
    public class Course:Training
    {
        public Course()
        {
            TrainingTypeId = (long) TrainingTypeEnum.Course;
        }
    }
}
