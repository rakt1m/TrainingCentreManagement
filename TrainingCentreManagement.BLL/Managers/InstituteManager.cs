using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class InstituteManager : Manager<Institute>,IInstituteManager
    {
        public InstituteManager(IInstituteRepository repository) : base(repository)
        {
        }
    }
}
