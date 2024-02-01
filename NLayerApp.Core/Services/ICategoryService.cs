using NLayerApp.Core.DTOs;
using NLayerApp.Core.DTOs.Category;
using NLayerApp.Core.Models;

namespace NLayerApp.Core.Services;

public interface ICategoryService:IService<Category>
{
    Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryWithProductsByIdAsync(int categoryId);
}