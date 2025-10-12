namespace GestionCatalogo.Application.Features.Products.Dtos;

// Este DTO se usa para recibir los datos al crear un nuevo producto.
public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}