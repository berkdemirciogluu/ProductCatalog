using ProductCatalog.Business.Constants;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.CategoryRules
{
    public class CategoryRule : ICategoryRule
    {
        ICategoryRepository _categoryRepository;

        public CategoryRule(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IResult CheckIfCategoryNameExist(string categoryName)
        {
            var result = _categoryRepository.GetAll(p => p.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult CheckIfCategoryInvalid(int id)
        {
            var result = _categoryRepository.GetById(id);
            if (result == null)
            {
                return new ErrorResult(Messages.CategoryInvalid);
            }
            return new SuccessResult();
        }
    }
}
