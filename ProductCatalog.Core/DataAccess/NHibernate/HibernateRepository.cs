using ProductCatalog.Core.Entities;
using System.Linq.Expressions;

namespace ProductCatalog.Core.DataAccess.NHibernate
{
    public class HibernateRepository<Entity> : IHibernateRepository<Entity> where Entity : class, IEntity,new()
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
