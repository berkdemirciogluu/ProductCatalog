using ProductCatalog.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Abstract
{
    public interface IProductService
    {
        IResult GetAll();
    }
}
