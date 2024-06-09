using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

/// <summary>
/// Интерфейс для доступа к профилям пользователей.
/// </summary>
public interface IUserProfileRepository
{
    /// <summary>
    /// Получить профиль пользователя по индетификатору.
    /// </summary>
    /// <param name="id"> Индетификатор профиля пользователя. </param>
    /// <returns> Профиль пользователя. </returns>
    public Task<UserProfile?> GetById(long id);

    /// <summary>
    /// Получить профиль пользователя по индетификатору пользователя.
    /// </summary>
    /// <param name="userId"> Индетификатор пользователя. </param>
    /// <returns> Профиль пользователя. </returns>
    public Task<UserProfile?> GetByUserId(long userId);

    /// <summary>
    /// Добавить профиль пользователя.
    /// </summary>
    /// <param name="userProfile"> Профиль. </param>
    public Task Add(UserProfile userProfile);

    /// <summary>
    /// Изменить профиль пользователя.
    /// </summary>
    /// <param name="userProfile"> Профиль. </param>
    public Task Update(UserProfile userProfile);
}
