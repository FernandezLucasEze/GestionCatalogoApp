using GestionCatalogo.Domain.Entities;

namespace GestionCatalogo.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
}