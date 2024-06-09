using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core;

/// <summary>
/// Профиль пользователя
/// </summary>
public class UserProfile
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; set; }
    public long UserId { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; } = string.Empty;

    /// <summary>
    /// Фотография
    /// </summary>
    public byte[]? ProfilePic { get; set; }

    /// <summary>
    /// Метод для получения полного имени
    /// </summary>
    /// <returns> Строку, содержащую имя и фамилию </returns>
    public string GetFullName()
    {
        return $"{Name} {Surname}";
    }
}
