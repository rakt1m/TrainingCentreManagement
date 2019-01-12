using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.Trainings;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class CourseManager:Manager<Course>,ICourseManager
    {
        public CourseManager(ICourseRepository repository) : base(repository)
        {
        }
    }
}
