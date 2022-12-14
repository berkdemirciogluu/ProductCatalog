namespace ProductCatalog.Entities.Concrete
{
    public class User : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] PasswordSalt { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual bool Status { get; set; }

    }
}
