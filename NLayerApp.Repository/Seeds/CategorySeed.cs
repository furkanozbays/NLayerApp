using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core;
using NLayerApp.Core.Models;

namespace NLayerApp.Repository.Seeds;

public class CategorySeed:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category{Id=1,Name="Nova Company"},
            new Category{Id=2,Name="İklim Company"},
            new Category{Id=3,Name="Oluş Company"}
        );
    }
}