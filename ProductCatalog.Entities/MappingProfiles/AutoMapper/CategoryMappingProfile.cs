using AutoMapper;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.MappingProfiles.AutoMapper
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CommandCategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

        }

    }
}
