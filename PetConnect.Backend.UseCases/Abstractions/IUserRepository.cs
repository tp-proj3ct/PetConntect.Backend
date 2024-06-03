using PetConnect.Backend.Core.Abstractions;

using PasswordOptions = PetConnect.Backend.Core.Options.PasswordOptions;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IUserRepository
{
    IAsyncEnumerable<User> GetAll();

    Task<User?> Resolve(string login, string password);

    Task<User?> GetById(long id);
    Task<User?> GetByLogin(string login);
    Task<User?> GetByEmail(string email);

    Task ChangeEmail(User user, string email);
    Task ChangePassword(User user, string password, PasswordOptions passwordOptions);

    Task Add(User user);
    Task Update(User user);
    Task Delete(User user);
}
