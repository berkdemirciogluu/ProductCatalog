using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.DTOs.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Abstract
{
    public interface IAccountService
    {
        IDataResult<List<GetUserOfferDto>> GetUserOffers(string userId);
        IDataResult<List<GetUserOfferDto>> GetUserOfferedProducts(string userId);
    }
}
