using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers;

public class CategoriesController : CustomBaseController
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
    {
        return CreateActionResult(await _service.GetCategoryWithProductsByIdAsync(categoryId));
    }
}