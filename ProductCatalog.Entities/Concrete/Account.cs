using ProductCatalog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.Concrete
{
    public class Account : BaseEntity, IEntity
    {
        public virtual int AccountId { get; set; }
        public virtual Product Product { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual int UserId { get; set; }



    }
}
