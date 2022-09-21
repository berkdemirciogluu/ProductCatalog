using AutoMapper;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Business.Constants;

namespace ProductCatalog.Business.Services.Base
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TEntity : BaseEntity
    {
        protected readonly IHibernateRepository<TEntity> _hibernateRepository;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IHibernateRepository<TEntity> hibernateRepository)
        {
            _mapper = mapper;
            _hibernateRepository = hibernateRepository;
        }

        public virtual IDataResult<TDto> Add(TDto dto)
        {

            //var tempEntity = Mapper.Map<Dto, Entity>(insertResource);
            //_hibernateRepository.Add(tempEntity);
            return new SuccessDataResult<TDto>(Messages.CategoryAdded);
        }

        public IDataResult<TDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<TDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<TDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<TDto> Update(int id, TDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
