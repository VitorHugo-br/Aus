using ProjetoAus.Data.Context;
using ProjetoAus.Data.interfaces;
using ProjetoAus.Models;

namespace ProjetoAus.Data.Repositories;

public class ProductRepository(AusDbContext ausDbContext) : RepositoryBase<Product>(ausDbContext), IProductRepository {}