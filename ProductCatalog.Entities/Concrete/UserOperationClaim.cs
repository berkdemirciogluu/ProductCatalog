using ProductCatalog.Core.Entities;

namespace ProductCatalog.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        public virtual int UserId { get; set; }
        public virtual int OperationClaimId { get; set; }
    }
}
