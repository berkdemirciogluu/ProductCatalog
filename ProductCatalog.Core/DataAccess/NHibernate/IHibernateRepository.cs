using ProductCatalog.Core.Entities;
using ProductCatalog.Entities.Concrete;
using System.Linq.Expressions;

namespace ProductCatalog.Core.DataAccess.NHibernate
{
    public interface IHibernateRepository<TEntity> where TEntity : BaseEntity
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void CloseTransaction();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);

        IQueryable<TEntity> Entities { get; }

        void StartTransactionalOperation(Operation operation, TEntity entity, TEntity? entityFromBody = null);
    }
}
