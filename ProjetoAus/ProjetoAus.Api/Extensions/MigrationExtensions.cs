using ProjetoAus.BLL.Services;
using ProjetoAus.Data.Context;
using ProjetoAus.Data.Configuration; 

namespace ProjetoAus.Api.Extensions;

public static class MigrationExtensions
{
    public static async Task ApplyMigrationsAndSeedAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
    
        for (int i = 0; i < 5; i++)
        {
            try
            {
                var context = services.GetRequiredService<AusDbContext>();
                var hashService = services.GetRequiredService<HashService>();
            
                await DbSeeder.SeedAsync(context, hashService);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tentativa {i + 1} falhou. O banco pode estar iniciando... Erro: {ex.Message}");
                await Task.Delay(5000); 
            }
        }
    }
}