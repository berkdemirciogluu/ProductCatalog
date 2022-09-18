using NHibernate;
using ProductCatalog.DataAccess.NHibernate.Context;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Concrete
{
    public class UserRepository : HibernateRepository<User>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (ISession _session = NHibernatePostgreSqlContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {

                    var result = from opertaionClaim in _session.Query<OperationClaim>()
                                 join userOperationClaim in _session.Query<UserOperationClaim>()
                                    on opertaionClaim.Id equals userOperationClaim.OperationClaimId
                                 where userOperationClaim.UserId == user.Id
                                 select new OperationClaim { Id = opertaionClaim.Id, Name = opertaionClaim.Name };

                    return result.ToList();
                }
            }
        }
    }
}
