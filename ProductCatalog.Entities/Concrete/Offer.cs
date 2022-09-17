namespace ProductCatalog.Entities.Concrete
{
    public class Offer : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual bool IsSold { get; set; } = false;
        public virtual double OfferedPrice { get; set; }

    }
}
