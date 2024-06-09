using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core.Users;
/// <summary>
/// Сиделка
/// </summary>
public class PetSitter : User
{
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Средний рейтинг
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Опыт работы
    /// </summary>
    public int ExperienceYears { get; set; }

    /// <summary>
    /// Предоставляемые услуги
    /// </summary>
    public ICollection<Service>? Services { get; set; }

    /// <summary>
    /// Отзывы
    /// </summary>
    public ICollection<Review>? Reviews { get; set; }
}
    