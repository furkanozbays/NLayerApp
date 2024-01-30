using AutoMapper;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.DTOs.Product;
using NLayerApp.Core.Models;

namespace NLayerApp.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>();
    }
}