using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Base
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity>
    {
        public Core.Utilities.Results.IDataResult<TDto> Add(TDto dto)
        {
            throw new NotImplementedException();
        }

        public Core.Utilities.Results.IDataResult<TDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Core.Utilities.Results.IDataResult<List<TDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Core.Utilities.Results.IDataResult<TDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Core.Utilities.Results.IDataResult<TDto> Update(int id, TDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
