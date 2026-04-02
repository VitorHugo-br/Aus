using ProjetoAus.Data.interfaces;
using ProjetoAus.Data.Repositories;
using ProjetoAus.Models.Interfaces;

namespace ProjetoAus.Api.Extensions;

public static class DataExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}