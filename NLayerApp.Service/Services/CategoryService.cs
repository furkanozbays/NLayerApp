using AutoMapper;
using NLayerApp.Core;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.DTOs.Category;
using NLayerApp.Core.Models;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;

namespace NLayerApp.Service.Services;

public class CategoryService:Service<Category>,ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    
    public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryWithProductsByIdAsync(int categoryId)
    {
        var category =await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);
        var categoryWithProductsDto = _mapper.Map<CategoryWithProductsDto>(category);
        return CustomResponseDto<CategoryWithProductsDto>.Success(categoryWithProductsDto, 200);
    }
}