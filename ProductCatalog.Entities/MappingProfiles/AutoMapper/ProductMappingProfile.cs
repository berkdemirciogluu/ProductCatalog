using AutoMapper;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.MappingProfiles.AutoMapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<AddProductDto, Product>().ReverseMap();
        }
    }
}
