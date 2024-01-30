using NLayerApp.Core.DTOs;
using NLayerApp.Core.Models;

namespace NLayerApp.Core.Services;

public interface IProductService:IService<Product>   
{
    Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync();
}