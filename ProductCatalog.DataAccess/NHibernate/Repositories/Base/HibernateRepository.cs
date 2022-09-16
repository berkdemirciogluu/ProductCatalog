using NHibernate;
using ProductCatalog.DataAccess.NHibernate.Context;
using ProductCatalog.Entities.Concrete;
using System.Linq.Expressions;

namespace ProductCatalog.Core.DataAccess.NHibernate
{
    public class HibernateRepository<TEntity> : IHibernateRepository<TEntity> where TEntity : BaseEntity
    {
        //private readonly ISession _session; 
        //private ITransaction _transaction; 

        //public HibernateRepository(ISession session)
        //{
        //    _session = session;
        //}
        //public IQueryable<TEntity> Entities => _session.Query<TEntity>();


        //public  List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        //{
        //    return filter == null
        //        ?  _session.Query<TEntity>().Where(e => e.IsDeleted == false).ToList()
        //        :  _session.Query<TEntity>().Where(filter).ToList().Where(e => e.IsDeleted == false).ToList();
        //}

        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    return _session.Query<TEntity>().Where(e => e.IsDeleted == false).SingleOrDefault(filter);
        //}

        //public TEntity GetById(int id)
        //{
        //    return  _session.Query<TEntity>().Where(e => e.IsDeleted == false).SingleOrDefault(e => e.Id == id);
        //}

        //public void Add(TEntity entity)
        //{
        //     _session.Save(entity);
        //}

        //public void Update(TEntity entity)
        //{
        //     _session.Update(entity);
        //}

        //public void Delete(TEntity entity)
        //{
        //    _session.Delete(entity);              
        //}

        //public void BeginTransaction()
        //{
        //    _transaction = _session.BeginTransaction();
        //}

        //public void CommitTransaction()
        //{
        //     _transaction.Commit();
        //}

        //public void RollbackTransaction()
        //{
        //    _transaction.Rollback();
        //}

        //public void CloseTransaction()
        //{
        //    if (_transaction != null)
        //    {
        //        _transaction.Dispose();
        //        _transaction = null;
        //    }
        //}
        //public virtual void StartTransactionalOperation(Operation operation, TEntity entity, TEntity? entityFromBody = null)
        //{
        //    try
        //    {
        //        BeginTransaction();

        //        switch (operation)
        //        {
        //            case Operation.Add:
        //                 Add(entity);
        //                break;
        //            case Operation.Update:
        //                 Update(entity);
        //                break;
        //            case Operation.Delete:
        //                 Delete(entity);
        //                break;
        //        }

        //         CommitTransaction();
        //    }
        //    catch
        //    {
        //         RollbackTransaction();
        //    }
        //    finally
        //    {
        //        CloseTransaction();
        //    }
        //}
        //public enum Operation {Empty, Add, Update, Delete }

        public HibernateRepository()
        {

        }
        public IQueryable<TEntity> Entities => throw new NotImplementedException();

        public void Add(TEntity entity)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entity);
                        _transaction.Commit();

                    }
                    catch (Exception ex)
                    {

                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public void Delete(TEntity entity)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Delete(entity);
                        _transaction.Commit();

                    }
                    catch (Exception ex)
                    {

                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                return _session.Query<TEntity>().Where(e => e.IsDeleted == false).SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                return filter == null
                ? _session.Query<TEntity>().Where(e => e.IsDeleted == false).ToList()
                : _session.Query<TEntity>().Where(filter).ToList().Where(e => e.IsDeleted == false).ToList();
            }            
        }

        public TEntity GetById(int id)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                return _session.Query<TEntity>().Where(e => e.IsDeleted == false).SingleOrDefault(e => e.Id == id);
            }
        }

        public void Update(TEntity entity)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Update(entity);
                        _transaction.Commit();

                    }
                    catch (Exception ex)
                    {

                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
    

}
