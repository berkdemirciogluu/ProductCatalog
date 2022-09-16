using ProductCatalog.Core.Entities;

namespace ProductCatalog.Entities.Concrete
{
    public class User : BaseEntity
    {
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] PasswordSalt { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual bool Status { get; set; }
        public virtual DateTime LastActivity { get; set; }

    }
}
