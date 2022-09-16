using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Core.DataAccess.NHibernate
{
    public class HibernateRepository<Entity> : IHibernateRepository<Entity> where Entity : class
    {
        public IQueryable<Entity> Entities => throw new NotImplementedException();

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CloseTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entity Get(Expression<Func<Entity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Entity> GetAll(Expression<Func<Entity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Entity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Save(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
