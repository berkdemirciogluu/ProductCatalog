namespace ProductCatalog.Entities.Concrete
{
    public class Account : BaseEntity
    {
        public virtual int UserId { get; set; }
        public virtual Product Product { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }

    }
}
