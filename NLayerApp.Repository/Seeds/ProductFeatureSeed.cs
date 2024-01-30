using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core.Models;

namespace NLayerApp.Repository.Seeds;

public class ProductFeatureSeed:IEntityTypeConfiguration<ProductFeature>
{
    public void Configure(EntityTypeBuilder<ProductFeature> builder)
    {
        builder.HasData(
            new ProductFeature { Id = 1, Color = "Mavi", ProductId = 1, Length = 100, Width = 200 },
            new ProductFeature { Id = 2, Color = "Kırmızı", ProductId = 2, Length = 300, Width = 400 },
            new ProductFeature { Id = 3, Color = "Sarı", ProductId = 3, Length = 500, Width = 600 },
            new ProductFeature { Id = 4, Color = "Yeşil", ProductId = 4, Length = 700, Width = 800 },
            new ProductFeature { Id = 5, Color = "Mor", ProductId = 5, Length = 900, Width = 1000 }
            );
    }
}