using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.Trainings;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.Repositories.Repositories
{
   public class CourseRepository:Repository<Course>,ICourseRepository
    {
        ApplicationDbContext db=new ApplicationDbContext();
        public override ICollection<Course> GetAll()
        {
          return  db.Courses.Include(n => n.TrainingType).ToList();
        }

        public override Course GetById(long? id)
        {
            return db.Courses.Include(n => n.TrainingType).FirstOrDefault(n=>n.Id==id);
        }
    }
}
