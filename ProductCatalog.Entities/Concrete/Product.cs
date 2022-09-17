using ProductCatalog.Core.Entities.Concrete;

namespace ProductCatalog.Entities.Concrete
{
    public class Product : BaseEntity
    {
        //public virtual int CategoryId { get; set; }
        //public virtual int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Offer> Offers { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsOfferable { get; set; } = false;
        public virtual bool IsSold { get; set; } = false;
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual double Price { get; set; }

    }
}
