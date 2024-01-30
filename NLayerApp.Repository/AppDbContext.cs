using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Models;

namespace NLayerApp.Repository;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  // apply all configurations in this assembly
        base.OnModelCreating(modelBuilder); 
    }
}