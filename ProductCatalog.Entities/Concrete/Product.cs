namespace ProductCatalog.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual int UserId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsOfferable { get; set; } = false;
        public virtual bool IsSold { get; set; }
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual double Price { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<User> Users { get; set; }

        public Product()
        {
            Offers = new List<Offer>();
            Users = new List<User>();
        }
    }
}
