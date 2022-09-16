using ProductCatalog.Business.Abstract;
using ProductCatalog.Core.DataAccess.NHibernate;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IResult Add(Category category)
        {
            _categoryRepository.StartTransactionalOperation(Operation.Add, category);
            return new SuccessResult();
        }

        public IResult GetAll()
        {
            _categoryRepository.GetAll();
            return new SuccessResult();
        }
    }
}
