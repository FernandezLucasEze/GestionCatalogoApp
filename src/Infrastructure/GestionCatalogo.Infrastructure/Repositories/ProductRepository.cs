using GestionCatalogo.Application.Contracts.Persistence;
using GestionCatalogo.Domain.Entities;
using GestionCatalogo.Infrastructure.Persistence;

namespace GestionCatalogo.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

}