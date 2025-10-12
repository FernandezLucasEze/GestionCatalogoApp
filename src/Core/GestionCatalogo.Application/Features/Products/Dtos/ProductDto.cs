namespace GestionCatalogo.Application.Features.Products.Dtos;

// Este DTO representa un producto que se envía al cliente.
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}