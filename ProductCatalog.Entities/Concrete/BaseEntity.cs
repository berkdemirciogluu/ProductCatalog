using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.Concrete
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
    }
}
