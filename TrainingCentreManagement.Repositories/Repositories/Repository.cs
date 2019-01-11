using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;
using TrainingCentreManagement.Repositories.Contracts;

namespace TrainingCentreManagement.Repositories.Repositories
{
   public abstract class Repository<T>:IRepository<T> where T:class
    {
        protected ApplicationDbContext db = new ApplicationDbContext();


        public DbSet<T> Table
        {
            get { return db.Set<T>(); }
        }



        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public virtual T GetById(int id)
        {
            return Table.Find(id);

        }
        public virtual ICollection<T> GetAll()
        {
            return Table
                .ToList();
        }
        public virtual bool Remove(T entity)
        {


            db.Entry(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;

        }



        public virtual bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
