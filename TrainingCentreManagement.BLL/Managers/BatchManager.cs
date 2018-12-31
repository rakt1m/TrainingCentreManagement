using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.BLL.Managers
{
   public class BatchManager:Manager<Batch>,IBatchManager
    {
        public BatchManager(IBatchRepository repository) : base(repository)
        {
        }
    }
}
