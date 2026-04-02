using ProjetoAus.BLL.Dto;
using ProjetoAus.Models;
using ProjetoAus.Models.Interfaces;

namespace ProjetoAus.BLL.Services;

public class AuthService(IUserRepository repository, TokenService tokenService, HashService hashService)
{
    public async Task<string?> AuthenticateAsync(LoginDto loginDto)
    {
        var user = await repository.GetUserAsync(loginDto.Username);
    
        if (user == null) return null;

        var isValid = hashService.VerifyHash(loginDto.Password, user.Password);
    
        return isValid ? tokenService.GenerateToken(user) : null;
    }

    public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
    {
        var existing = await repository.GetUserAsync(registerDto.Username);
        if (existing != null) return false;
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            UserName = registerDto.Username.Trim(),
            Password = hashService.GenerateHash(registerDto.Password)
        };
        await repository.CreateAsync(newUser);
        return true;
    }
}