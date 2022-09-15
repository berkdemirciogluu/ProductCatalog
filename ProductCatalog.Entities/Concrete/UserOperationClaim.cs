using ProductCatalog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        public virtual int UserId { get; set; }
        public virtual int OperationClaimId { get; set; }
    }
}
