using FluentValidation;
using GestionCatalogo.Application.Features.Products.Dtos;

namespace GestionCatalogo.Application.Features.Products.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no puede exceder los 100 caracteres.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} no puede estar vacía.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor que cero.");

        RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} no puede ser negativo.");
    }
}