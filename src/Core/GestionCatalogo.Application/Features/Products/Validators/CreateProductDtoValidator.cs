using FluentValidation;
using GestionCatalogo.Application.Features.Products.Dtos;

namespace GestionCatalogo.Application.Features.Products.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        // Regla para el nombre del producto
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} no puede exceder los 100 caracteres.");

        // Regla para la descripción
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} no puede estar vacía.");

        // Regla para el precio
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor que cero.");

        // Regla para el stock
        RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} no puede ser negativo.");
    }
}