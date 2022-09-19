using AutoMapper;
using ProductCatalog.Business.BusinessAspects.Autofac.JWT;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Business.ValidationRules.CustomValidation.CategoryRules;
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
        private readonly ICategoryRules _categoryRules;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ICategoryRules categoryRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryRules = categoryRules;
        }

        [ValidationAspect(typeof(CommandCategoryDtoValidator))]
        [SecuredOperation("category.add,admin")]
        public IResult Add(CommandCategoryDto category)
        {
            IResult result = BusinessRules.Run(_categoryRules.CheckIfCategoryNameExist(category.CategoryName));

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

            IResult result = BusinessRules.Run(_categoryRules.CheckIfCategoryInvalid(id));

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
            IResult result = BusinessRules.Run(_categoryRules.CheckIfCategoryNameExist(category.CategoryName),
                                               _categoryRules.CheckIfCategoryInvalid(id));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var categoryToUpdate = _categoryRepository.GetById(id);
            categoryToUpdate.CategoryName = category.CategoryName != default ? category.CategoryName : categoryToUpdate.CategoryName;
            _categoryRepository.Update(categoryToUpdate);
            return new SuccessResult(Messages.CategoryUpdated);
        }



    }
}
