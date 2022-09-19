using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.DTOs.Offer
{
    public class MakeOfferDto
    {
        public virtual double OfferedPrice { get; set; }
        public virtual int ProductId { get; set; }
    }
}
