using ProductCatalog.Core.Entities;

namespace ProductCatalog.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public virtual string CategoryName { get; set; }
    }
}
