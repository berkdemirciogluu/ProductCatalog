using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.DTOs.Product
{
    public class UpdateProductDto
    {
        public virtual string ProductName { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Description { get; set; }
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual double Price { get; set; }
    }
}
