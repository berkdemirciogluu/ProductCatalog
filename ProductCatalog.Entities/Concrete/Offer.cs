namespace ProductCatalog.Entities.Concrete
{
    public class Offer : BaseEntity
    {
        public virtual int UserId { get; set; }
        public virtual int ProductId { get; set; }
        //public virtual User User { get; set; }
        //public virtual Product Product { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual bool IsSold { get; set; } 
        public virtual double OfferedPrice { get; set; }

    }
}
