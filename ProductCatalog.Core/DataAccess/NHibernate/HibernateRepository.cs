using NHibernate;
using NHibernate.Linq;
using ProductCatalog.Core.Entities;
using System.Linq.Expressions;

namespace ProductCatalog.Core.DataAccess.NHibernate
{
    public class HibernateRepository<TEntity> : IHibernateRepository<TEntity> where TEntity : class, IEntity,new()
    {
        private readonly ISession _session; 
        private ITransaction _transaction; 

        public HibernateRepository(ISession session)
        {
            _session = session;
        }
        public IQueryable<TEntity> Entities => _session.Query<TEntity>();


        public  List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                ?  _session.Query<TEntity>().ToList()
                :  _session.Query<TEntity>().Where(filter).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _session.Query<TEntity>().Where(filter).SingleOrDefault();
        }

        public TEntity GetById(int id)
        {
            return  _session.Get<TEntity>(id);
        }

        public void Add(TEntity entity)
        {
             _session.Save(entity);
        }

        public void Update(TEntity entity)
        {
             _session.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _session.Delete(entity);              
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void CommitTransaction()
        {
             _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
        public virtual void StartTransactionalOperation(Operation operation, TEntity entity, TEntity? entityFromBody = null)
        {
            try
            {
                BeginTransaction();

                switch (operation)
                {
                    case Operation.Add:
                         Add(entity);
                        break;
                    case Operation.Update:
                         Update(entity);
                        break;
                    case Operation.Delete:
                         Delete(entity);
                        break;
                }

                 CommitTransaction();
            }
            catch
            {
                 RollbackTransaction();
            }
            finally
            {
                CloseTransaction();
            }
        }
    }
    public enum Operation {Empty, Add, Update, Delete }
}
