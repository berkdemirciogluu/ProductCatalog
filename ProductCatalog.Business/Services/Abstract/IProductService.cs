using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.Business.Services.Abstract
{
    public interface IProductService
    {
        IDataResult<List<GetProductDto>> GetAll();
        IResult Add(AddProductDto entity);
        IResult Delete(int id);

    }
}
