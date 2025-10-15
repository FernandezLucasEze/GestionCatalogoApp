using GestionCatalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace GestionCatalogo.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
}