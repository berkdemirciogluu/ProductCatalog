using ProductCatalog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        public virtual int ProductId { get; set; }
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



    }
}
