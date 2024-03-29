using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLayerApp.API.Filters;
using NLayerApp.Core;
using NLayerApp.Core.Models;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;
using NLayerApp.Repository;
using NLayerApp.Repository.Repositories;
using NLayerApp.Repository.UnitOfWorks;
using NLayerApp.Service.Mapping;
using NLayerApp.Service.Services;
using NLayerApp.Service.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x =>
    x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

//add dbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        migration => { migration.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();