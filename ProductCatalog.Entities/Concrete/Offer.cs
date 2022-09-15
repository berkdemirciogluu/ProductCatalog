using ProductCatalog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.Concrete
{
    public class Offer : BaseEntity, IEntity
    {
        public virtual int OfferId { get; set; }
        public virtual int UserId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual bool IsSold { get; set; } = false;
        public virtual double OfferedPrice { get; set; }


    }
}
