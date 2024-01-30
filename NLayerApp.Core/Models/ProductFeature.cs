namespace NLayerApp.Core.Models;      

public class ProductFeature
{
    public int Id { get; set; }
    public string? Color { get; set; }
    public int Length  { get; set; }
    public int Width { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}