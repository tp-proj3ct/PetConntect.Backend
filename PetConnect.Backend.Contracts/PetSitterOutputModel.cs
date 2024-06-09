namespace PetConnect.Backend.Contracts;

/// <summary>
/// Модель сиделки
/// </summary>
public class PetSitterOutputModel
{
    /// <summary>
    /// Индетификатор
    /// </summary>
    public long Id { get; set; }

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
}
