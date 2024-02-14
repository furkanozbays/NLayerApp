using FluentValidation;
using NLayerApp.Core.DTOs;

namespace NLayerApp.Service.Validation;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Name).MaximumLength(200).WithMessage("Name can not be longer than 200 characters");
        RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock is required");
        RuleFor(x => x.Stock).GreaterThan((short)0).WithMessage("Stock must be greater than 0");
        RuleFor(x => x.Price)
            .InclusiveBetween(1,int.MaxValue).WithMessage("Price must be greater than 0")
            .NotEmpty().WithMessage("Price is required");
        
        RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("{PropertyName} is required ");
    }
}