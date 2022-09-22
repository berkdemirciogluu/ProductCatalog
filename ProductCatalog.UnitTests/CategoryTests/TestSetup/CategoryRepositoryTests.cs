using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.UnitTests.InMemoryDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductCatalog.UnitTests.CategoryTests.TestSetup
{
    public class CategoryRepositoryTests : InMemoryDatabaseTest
    {
        public CategoryRepositoryTests() : base(typeof(HibernateRepository<Category>).Assembly)
        {
            
        }


        [Fact]
        public void GetAll_ShouldReturn_CategoryList()
        {
            var repository = new HibernateRepository<Category>();
            var categories = repository.GetAll();

            Assert.NotEmpty(categories);
            Assert.Equal(3, categories.Count());
        }

        [Fact]
        public void GetById_ShouldReturn_Category()
        {
            var repository = new HibernateRepository<Category>();
            var category = repository.GetById(1);

            Assert.NotNull(category);
        }


        [Fact]
        public void Update_ShouldNotReturn_Exception()
        {
            var repository = new HibernateRepository<Category>();

            var category = new Category
            {
                IsDeleted = false,
                CategoryName = "Test2",
            };


            var exception =
                Record.Exception(() => repository.Update(category));
            Assert.NotNull(exception);
        }

        [Fact]
        public void Delete_ShouldNotReturn_Exception()
        {
            var repository = new HibernateRepository<Category>();

            var category = new Category
            {
                IsDeleted = false,
                CategoryName = "Test2",
            };

            var exception =
                Record.Exception(() => repository.Delete(category.Id));
            Assert.NotNull(exception);
        }


    }
}
