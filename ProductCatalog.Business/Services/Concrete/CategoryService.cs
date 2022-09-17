using AutoMapper;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
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

        public IResult Add(Category entity)
        {
            try
            {
                _categoryRepository.Add(entity);
                return new SuccessResult(Messages.CategoryAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CategoryNotAdded);
            }
        }

        public IResult Delete(int id)
        {
            var categoryToDelete = _categoryRepository.GetById(id);
            if (categoryToDelete == null)
            {
                return new ErrorResult(Messages.CategoryInvalid);
            }

            try
            {
                _categoryRepository.Delete(categoryToDelete.Id);
                return new SuccessResult(Messages.CategoryDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(Messages.CategoryNotDeleted);
            }
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll(),Messages.CategoryListed);
        }

        public IResult Update(Category entity, int id)
        {
            var categoryToUpdate = _categoryRepository.GetById(id);

            if(categoryToUpdate == null)
                return new ErrorResult(Messages.CategoryInvalid);

            try
            {
                categoryToUpdate.CategoryName = entity.CategoryName != default ? entity.CategoryName : categoryToUpdate.CategoryName;
                _categoryRepository.Update(categoryToUpdate);
                return new SuccessResult(Messages.CategoryUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CategoryNotUpdated);
            }
        }
    }
}
