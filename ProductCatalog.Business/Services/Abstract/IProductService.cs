﻿using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.Business.Services.Abstract
{
    public interface IProductService
    {
        IDataResult<List<GetProductDto>> GetAll();
        IResult Add(AddProductDto entity, string userId);
        IResult Delete(int id);
        IResult Update(UpdateProductDto entity, int id, string userId);

        //IDataResult<List<ProductOfferDto>> GetProductsOffer();
    }
}
