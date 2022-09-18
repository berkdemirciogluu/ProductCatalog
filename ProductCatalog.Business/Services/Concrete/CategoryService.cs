using AutoMapper;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Business.ValidationRules.FluentValidation.CategoryValidation;
using ProductCatalog.Core.Aspects.Autofac.Validation;
using ProductCatalog.Core.CrossCuttingConcerns.Validation;
using ProductCatalog.Core.Utilities.Business;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Category;

namespace ProductCatalog.Business.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        //[ValidationAspect(typeof(CommandCategoryDtoValidator))]
        public IResult Add(CommandCategoryDto category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExist(category.CategoryName));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var categoryToAdded = _mapper.Map<Category>(category);
            _categoryRepository.Add(categoryToAdded);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(int id)
        {

            IResult result = BusinessRules.Run(CheckIfCategoryInvalid(id));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var categoryToDelete = _categoryRepository.GetById(id);
            _categoryRepository.Delete(categoryToDelete.Id);

            return new SuccessResult(Messages.CategoryDeleted);

        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            var categories = _categoryRepository.GetAll();
            var result = _mapper.Map<List<CategoryDto>>(categories);

            return new SuccessDataResult<List<CategoryDto>>(result, Messages.CategoryListed);
        }

        [ValidationAspect(typeof(CommandCategoryDtoValidator))]
        public IResult Update(CommandCategoryDto category, int id)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExist(category.CategoryName),
                                               CheckIfCategoryInvalid(id));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var categoryToUpdate = _categoryRepository.GetById(id);
            categoryToUpdate.CategoryName = category.CategoryName != default ? category.CategoryName : categoryToUpdate.CategoryName;
            _categoryRepository.Update(categoryToUpdate);
            return new SuccessResult(Messages.CategoryUpdated);

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
