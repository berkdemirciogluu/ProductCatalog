using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.Business.Services.Abstract
{
    public interface IProductService
    {
        IDataResult<List<GetProductDto>> GetAll();
        IResult Add(AddProductDto entity, string userId);
        IResult Delete(int id);
        IResult Update(UpdateProductDto entity, int id, string userId);
        IDataResult<List<GetProductDto>> GetUserProducts(string userId);
        IDataResult<List<GetProductDto>> GetProductsByCategoryId(int categoryId);
        IResult UpdateIsOfferable(int id, string userId);
        IResult SellProduct(SellProductDto entity, string userId);
        IDataResult<List<GetProductOffersDto>> GetProductsForOffer();

    }
}
