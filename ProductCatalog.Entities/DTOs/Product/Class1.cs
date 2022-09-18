using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.DTOs.Product
{
    public class ProductOfferDto
    {
        public virtual int Id { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual double Price { get; set; }
    }
}
