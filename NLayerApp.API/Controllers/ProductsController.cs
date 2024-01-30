using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.DTOs.Product;
using NLayerApp.Core.DTOs.Response;
using NLayerApp.Core.Models;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : CustomBaseController
{
    private readonly IMapper _mapper;
    private readonly IService<Product> _service;

    public ProductsController(IMapper mapper, IService<Product> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var products = await _service.GetAllAsync();
        var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
        // return Ok(CustomResponseDto<List<ProductDto>>.Success(productsDtos, 200));
        return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(productsDtos, 200));
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return CreateActionResult(CustomResponseDto<ProductDto>.Success(productDto, 200));
    }
    
    [HttpPost]
    public async Task<IActionResult> Save(ProductDto productDto)
    {
        var newProduct = await _service.AddAsync(_mapper.Map<Product>(productDto));
        var newProductDto = _mapper.Map<ProductDto>(newProduct);
        return CreateActionResult(CustomResponseDto<ProductDto>.Success(newProductDto, 201));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
    {
        await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var product = await _service.GetByIdAsync(id);
        
        if (product == null)
        {
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail("Product not found", 404));
        }
        
        await _service.RemoveAsync(product);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
    
    
}