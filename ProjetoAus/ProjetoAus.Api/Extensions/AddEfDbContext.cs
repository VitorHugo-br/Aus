using Microsoft.EntityFrameworkCore;
using ProjetoAus.Data.Context;

namespace ProjetoAus.Api.Extensions;

public static class AddEfDbContext
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        services.AddDbContext<AusDbContext>(options => options.UseMySQL(connectionString));
        return services;
    }
}