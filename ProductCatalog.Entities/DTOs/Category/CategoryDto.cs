using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.DTOs.Category
{
    public class CategoryDto
    {
        public virtual int Id { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
