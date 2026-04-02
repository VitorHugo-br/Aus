using Microsoft.EntityFrameworkCore;
using ProjetoAus.Models;

namespace ProjetoAus.Data.Context;

public class AusDbContext(DbContextOptions<AusDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    
}