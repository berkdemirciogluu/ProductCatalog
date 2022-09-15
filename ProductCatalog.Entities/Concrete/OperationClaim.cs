using ProductCatalog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.Concrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public virtual string Name { get; set; }
    }
}
