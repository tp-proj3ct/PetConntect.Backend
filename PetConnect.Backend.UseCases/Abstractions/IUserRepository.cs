using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IUserRepository
{
    IAsyncEnumerable<User> GetAll();

    Task<User?> Resolve(string login, string password);
    Task<User?> GetById(long id);
    Task<User?> GetByLogin(string login);
    Task<User?> GetByEmail(string email);

    Task Add(User user);
    Task Update(User user);
    Task Delete(long id);
}
