using AutoMapper;
using NLayerApp.Core;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Models;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;

namespace NLayerApp.Service.Services;

public class ProductService:Service<Product>,IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync()
    {
        var products = await _productRepository.GetProductsWitCategory();
        var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
        
        return CustomResponseDto<List<ProductWithCategoryDto>>.Success(_mapper.Map<List<ProductWithCategoryDto>>(productsDto),200);
    }
}