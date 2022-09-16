using NHibernate;
using ProductCatalog.Core.Entities;
using ProductCatalog.DataAccess.NHibernate.Context;
using ProductCatalog.Entities.Concrete;
using System.Linq.Expressions;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Base
{
    public class HibernateRepository<TEntity> : IHibernateRepository<TEntity> where TEntity : BaseEntity
    {

        public IQueryable<TEntity> Entities => NHibernatePostgreSqlContext.SessionOpen().Query<TEntity>().OrderBy(x => x.Id);

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

        public void Delete(int id)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        var deletedEntity = GetById(id);
                        _session.Delete(deletedEntity);
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
                return _session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                return filter == null
                ? _session.Query<TEntity>().ToList()
                : _session.Query<TEntity>().Where(filter).ToList().ToList();
            }            
        }

        public TEntity GetById(int id)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                return _session.Query<TEntity>().SingleOrDefault(e => e.Id == id);
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
