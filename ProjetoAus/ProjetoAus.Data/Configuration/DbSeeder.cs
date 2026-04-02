using ProjetoAus.Models;

using ProjetoAus.Data.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoAus.BLL.Services;

namespace ProjetoAus.Data.Configuration;

public static class DbSeeder
{
    public static async Task SeedAsync(AusDbContext context, HashService hashService)
    {
        await context.Database.MigrateAsync();

        if (!await context.Users.AnyAsync(u => u.UserName == "admin"))
        {
            var defaultUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Password = hashService.GenerateHash("ausland123") 
            };

            await context.Users.AddAsync(defaultUser);
            await context.SaveChangesAsync();
            
        }
    }
}