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

        public IDataResult<TDto> Add(TDto dto)
        {
            var tempEntity = _mapper.Map<TDto, TEntity>(dto);
            _hibernateRepository.Add(tempEntity);
            return new SuccessDataResult<TDto>(_mapper.Map<TEntity, TDto>(tempEntity));
        }

        public IDataResult<TDto> Delete(int id)
        {
            var tempEntity = _hibernateRepository.GetById(id);
            if (tempEntity is null)
            {
                return new ErrorDataResult<TDto>("Record Not Found");
            }
            _hibernateRepository.Delete(id);
            return new SuccessDataResult<TDto>(_mapper.Map<TEntity, TDto>(tempEntity));
        }

        public IDataResult<List<TDto>> GetAll()
        {
            var tempEntity = _hibernateRepository.GetAll();
            var result = _mapper.Map<List<TEntity>, List<TDto>>(tempEntity);
            return new SuccessDataResult<List<TDto>>(result);
        }

        public IDataResult<TDto> GetById(int id)
        {
            var tempEntity = _hibernateRepository.GetById(id);
            var result = _mapper.Map<TEntity, TDto>(tempEntity);
            return new SuccessDataResult<TDto>(result);
        }

        public IDataResult<TDto> Update(int id, TDto dto)
        {
            var tempEntity = _hibernateRepository.GetById(id);
            if (tempEntity is null)
            {
                return new SuccessDataResult<TDto>("Record Not Found");
            }
            var entity = _mapper.Map<TDto, TEntity>(dto, tempEntity);
            _hibernateRepository.Update(entity);
            var resource = _mapper.Map<TEntity, TDto>(entity);
            return new SuccessDataResult<TDto>(resource);

        }
    }
}
