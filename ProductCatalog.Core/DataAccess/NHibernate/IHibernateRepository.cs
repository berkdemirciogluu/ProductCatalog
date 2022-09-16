using ProductCatalog.Core.Entities;
using System.Linq.Expressions;

namespace ProductCatalog.Core.DataAccess.NHibernate
{
    public interface IHibernateRepository<TEntity> where TEntity : class,IEntity,new()
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);

        IQueryable<TEntity> Entities { get; }
    }
}
