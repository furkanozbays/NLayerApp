using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core.Models;

namespace NLayerApp.Repository.Seeds;

public class ProductSeed:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product{Id=1,Name="7001",Price=500,Stock=100,CategoryId=1},
            new Product{Id=2,Name="1053",Price=400,Stock=200,CategoryId=2},
            new Product{Id=3,Name="750",Price=300,Stock=300,CategoryId=3},
            new Product{Id=4,Name="1050",Price=200,Stock=400,CategoryId=2},
            new Product{Id=5,Name="750",Price=100,Stock=500,CategoryId=1}
        );
    }
}