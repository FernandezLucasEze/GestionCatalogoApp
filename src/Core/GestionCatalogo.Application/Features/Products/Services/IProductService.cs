using GestionCatalogo.Application.Features.Products.Dtos; // Usamos DTOs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionCatalogo.Application.Features.Products.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
    Task<bool> UpdateProductAsync(int id, CreateProductDto updateProductDto);
    Task<bool> DeleteProductAsync(int id);
}