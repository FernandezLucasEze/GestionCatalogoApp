using GestionCatalogo.Domain.Entities;

namespace GestionCatalogo.Application.Features.Products.Services;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
}