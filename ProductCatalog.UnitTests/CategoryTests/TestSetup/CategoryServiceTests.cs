using AutoMapper;
using Moq;
using ProductCatalog.Business.Services.Concrete;
using ProductCatalog.Business.ValidationRules.FluentValidation.CategoryValidation;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.DTOs.Category;
using ProductCatalog.Entities.MappingProfiles;
using ProductCatalog.UnitTests.CategoryTests.ArtificialData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductCatalog.UnitTests.CategoryTests.TestSetup
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly IMapper _mapper;
        public CategoryServiceTests()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));

        }

        [Fact]
        public void CreateCategory_ShouldReturn_NotSavedException()
        {
            _categoryRepositoryMock.Setup(u => u.Add(CategoryArtficialData.GetCategoriesData().FirstOrDefault()));

            var validator = new CommandCategoryDtoValidator();

            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapper);
            var exception =
                Record.Exception(() => validator.ValidateAndThrow(DataWareHouse.GetCommandCategoryViewModel()));


            Assert.Throws<NotSavedExceptions>(() =>
                categoryService.Create(DataWareHouse.GetCommandCategoryViewModel()));

            Assert.Null(exception);
        }

        [Fact]
        public void UpdateCategory_ShouldReturn_NotSavedException()
        {
            //Arrange
            _unitOfWorkMock.Setup(u => u.Category).Returns(_categoryRepositoryMock.Object);

            var category = DataWareHouse.GetCategoriesData().FirstOrDefault();
            var validator = new CommandCategoryViewModelValidator();
            _unitOfWorkMock.Setup(u => u.Category.GetById(category.Id)).Returns(category);

            //Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapper);
            var exception =
                Record.Exception(() => validator.ValidateAndThrow(DataWareHouse.GetCommandCategoryViewModel()));

            //Assert
            Assert.Throws<NotSavedExceptions>(() =>
                categoryService.Update(DataWareHouse.GetCommandCategoryViewModel(), category.Id));
            Assert.Null(exception);
        }

        [Fact]
        public void DeleteCategory_ShouldReturn_NotSavedException()
        {
            //Arrange
            _unitOfWorkMock.Setup(u => u.Category).Returns(_categoryRepositoryMock.Object);
            var category = DataWareHouse.GetCategoriesData().FirstOrDefault();
            var validator = new CommandCategoryViewModelValidator();
            _unitOfWorkMock.Setup(u => u.Category.GetById(category.Id)).Returns(category);


            //Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapper);
            var exception =
                Record.Exception(() => validator.ValidateAndThrow(DataWareHouse.GetCommandCategoryViewModel()));

            //Assert
            Assert.Throws<NotSavedExceptions>(() =>
                categoryService.Delete(category.Id));

            Assert.Null(exception);
        }
    }
}
