namespace ProjetoAus.Models.Interfaces;

public interface IUserRepository: IRepositoryBase<User>
{
    Task<User?> GetUserAsync(string username);
}