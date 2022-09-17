namespace ProductCatalog.Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int OperationClaimId { get; set; }
    }
}
