namespace ProductCatalog.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual int UserId { get; set; }
        public virtual int OfferId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsOfferable { get; set; } = true;
        public virtual bool IsSold { get; set; } = false;
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual double Price { get; set; }

    }
}
