namespace ProductCatalog.Entities.Concrete
{
    public class Offer : BaseEntity
    {
        public virtual int UserId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual bool IsSold { get; set; } = false;
        public virtual double OfferedPrice { get; set; }

    }
}
