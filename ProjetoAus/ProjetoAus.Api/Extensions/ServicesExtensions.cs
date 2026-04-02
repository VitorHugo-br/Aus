using ProjetoAus.BLL.Services;

namespace ProjetoAus.Api.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<TokenService>();
        services.AddScoped<AuthService>();
        services.AddScoped<HashService>();
        services.AddScoped<ProductService>();
        return  services;
    }
}