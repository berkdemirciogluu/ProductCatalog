namespace ProductCatalog.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual int OperationClaimId { get; set; }
    }
}
