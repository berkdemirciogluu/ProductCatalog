using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.DTOs.Product
{
    public class SellProductDto
    {
        public virtual int ProductId { get; set; }
        public virtual double Price { get; set; }
    }
}
