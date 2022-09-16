using ProductCatalog.Core.Entities;

namespace ProductCatalog.Entities.Concrete
{
    public class Account : BaseEntity, IEntity
    {
        public virtual Product Product { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual int UserId { get; set; }



    }
}
