using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.UseCases.Abstractions;

/// <summary>
/// Сервис для работы с токенами.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Генерация токена доступа.
    /// </summary>
    /// <param name="user"> Пользователь. </param>
    /// <returns> Access токен </returns>
    public Token GenerateToken(User user);
}
