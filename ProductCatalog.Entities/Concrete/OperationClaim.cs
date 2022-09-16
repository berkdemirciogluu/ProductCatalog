using ProductCatalog.Core.Entities;

namespace ProductCatalog.Entities.Concrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public virtual string Name { get; set; }
    }
}
