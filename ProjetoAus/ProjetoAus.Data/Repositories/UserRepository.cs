using Microsoft.EntityFrameworkCore;
using ProjetoAus.Data.Context;
using ProjetoAus.Models;
using ProjetoAus.Models.Interfaces;

namespace ProjetoAus.Data.Repositories;

public class UserRepository(AusDbContext ausDbContext) : RepositoryBase<User>(ausDbContext), IUserRepository
{
    private readonly AusDbContext _ausDbContext = ausDbContext;

    public async Task<User?> GetUserAsync(string username)
    {
        if (string.IsNullOrWhiteSpace(username)) return null;
        return await _ausDbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }
}