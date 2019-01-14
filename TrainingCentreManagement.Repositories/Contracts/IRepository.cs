using System.Collections.Generic;

namespace TrainingCentreManagement.Repositories.Contracts
{
   public interface IRepository<T> where T: class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetById(long? id);
        ICollection<T> GetAll();
    }
}
