namespace ProjetoAus.BLL.Services;

public class HashService
{
    public string GenerateHash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyHash(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}