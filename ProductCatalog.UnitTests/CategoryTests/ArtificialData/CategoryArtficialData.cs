using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.UnitTests.CategoryTests.ArtificialData
{
    public static class CategoryArtficialData
    {
        public static List<Category> GetCategoriesData()
        {
            var result = new List<Category>
            {
                new Category {Id = 1, IsDeleted = false, CategoryName = "Test1"},
                new Category {Id = 2, IsDeleted = false, CategoryName = "Test2"},
                new Category {Id = 3, IsDeleted = false, CategoryName = "Test3"},

            }.ToList();

            return result;
        }

        public static CommandCategoryDto GetCommandCategoryViewModel()
        {
            return new CommandCategoryDto { CategoryName = "Test1" };
        }
    }
}
