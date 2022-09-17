﻿using AutoMapper;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Category;
using ProductCatalog.Entities.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommandCategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();

        }
    }
}