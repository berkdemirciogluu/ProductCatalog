namespace ProductCatalog.Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
