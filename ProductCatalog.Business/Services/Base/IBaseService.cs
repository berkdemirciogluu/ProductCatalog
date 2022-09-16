using ProductCatalog.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Base
{
    public interface IBaseService<TDto, TEntity>
    {
        IDataResult<TDto> GetById(int id);
        IDataResult<List<TDto>> GetAll();
        IDataResult<TDto> Add(TDto dto);
        IDataResult<TDto> Update(int id, TDto dto);
        IDataResult<TDto> Delete(int id);
    }
}
