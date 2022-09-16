using ProductCatalog.Core.Entities;
using ProductCatalog.Entities.Concrete;
using System.Linq.Expressions;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Base
{
    public interface IHibernateRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);

        IQueryable<TEntity> Entities { get; }

    }
}
