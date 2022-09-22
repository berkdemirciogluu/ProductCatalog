namespace ProductCatalog.Entities.Concrete
{
    public class Account : BaseEntity
    {
        public virtual int UserId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int OfferId { get; set; }


    }
}
