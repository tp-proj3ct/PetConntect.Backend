using PetConnect.Backend.Core.Abstractions;

using PasswordOptions = PetConnect.Backend.Core.Options.PasswordOptions;

namespace PetConnect.Backend.UseCases.Abstractions;

/// <summary>
/// Репозиторий для доступа к пользователям.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получить всех пользователей.
    /// </summary>
    /// <returns> Список пользвателей </returns>
    IAsyncEnumerable<User> GetAll();

    /// <summary>
    /// Получить пользователя.
    /// </summary>
    /// <param name="login"> Логин пользователя. </param>
    /// <param name="password"> Пароль пользователя. </param>
    /// <returns> Пользователь. </returns>
    Task<User?> Resolve(string login, string password);

    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id"> Идентификатор пользователя. </param>
    /// <returns> Пользователь. </returns>
    Task<User?> GetById(long id);

    /// <summary>
    /// Получить пользователя по логину.
    /// </summary>
    /// <param name="login"> Логин пользователя. </param>
    /// <returns> Пользователь. </returns>
    Task<User?> GetByLogin(string login);

    /// <summary>
    /// Получить пользователя по почте.
    /// </summary>
    /// <param name="email"> Почта пользователя. </param>
    /// <returns> Пользователь. </returns>
    Task<User?> GetByEmail(string email);

    /// <summary>
    /// Изменить почту пользователя.
    /// </summary>
    /// <param name="user"> Пользователь. </param>
    /// <param name="email"> Новая почта.</param>
    Task ChangeEmail(User user, string email);

    /// <summary>
    /// Изменить пароль пользователя.
    /// </summary>
    /// <param name="user"> Пользователь. </param>
    /// <param name="password"> Новый пароль. </param>
    /// <param name="passwordOptions"> Параметры пароля. </param>
    Task ChangePassword(User user, string password, PasswordOptions passwordOptions);

    /// <summary>
    /// Добавить пользователя.
    /// </summary>
    /// <param name="user"> Пользователь. </param>
    Task Add(User user);

    /// <summary>
    /// Отредактировать пользователя.
    /// </summary>
    /// <param name="user"> Пользователь. </param>
    Task Update(User user);

    /// <summary>
    /// Удалить пользователя.
    /// </summary>
    /// <param name="user"> Пользователь</param>
    Task Delete(User user);
}
