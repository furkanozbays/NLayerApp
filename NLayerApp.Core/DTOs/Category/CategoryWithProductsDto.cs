namespace NLayerApp.Core.DTOs.Category;

public class CategoryWithProductsDto:CategoryDto
{
    public List<ProductDto> Products { get; set; }
}