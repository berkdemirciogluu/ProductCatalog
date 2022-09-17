namespace ProductCatalog.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsOfferable { get; set; } = false;
        public virtual bool IsSold { get; set; }
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual double Price { get; set; }

    }
}
