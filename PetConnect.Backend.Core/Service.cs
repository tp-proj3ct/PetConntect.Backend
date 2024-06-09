using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.Core;

/// <summary>
/// Услуга
/// </summary>
public class Service
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Сиделка
    /// </summary>
    public PetSitter? PetSitter { get; set; }
    public long PetSitterId { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; }
}
