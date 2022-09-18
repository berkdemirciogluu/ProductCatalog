using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {
        public virtual int UserId { get; set; }
        public virtual int OperationClaimId { get; set; }
    }
}
