using PetConnect.Backend.Core.Options;
using PetConnect.Backend.Core.Services;

namespace PetConnect.Backend.Core.Abstractions;

/// <summary>
/// Пользовватель
/// </summary>
public abstract class User
{
    /// <summary>
    /// Индетификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = string.Empty;

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Хэш пароля
    /// </summary>
    public string PasswordHash { get; private set; } = string.Empty;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Роль
    /// </summary>
    public Role Role { get; set; } = Role.None;

    /// <summary>
    /// Заблокирован (да, нет)
    /// </summary>
    public bool IsBlocked { get; set; } = false;

    /// <summary>
    /// Сеттер пароля
    /// </summary>
    /// <param name="password"> Строка пароля</param>
    /// <param name="passwordOptions"> Параметры пароля</param>
    public void SetPassword(string password, PasswordOptions passwordOptions)
    {
        PasswordHash = CryptographyService.HashPassword(password, passwordOptions.Salt);
    }
}
