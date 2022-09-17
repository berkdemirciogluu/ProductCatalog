using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<CategoryDto>> GetAll();
        IResult Add(CommandCategoryDto entity);
        IResult Delete(int id);
        IResult Update(CommandCategoryDto entity,int id);
    }
}
