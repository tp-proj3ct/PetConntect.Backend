using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core;

/// <summary>
/// Питомец
/// </summary>
public class Pet
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    public long PetOwnerId { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Вес
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Описание поведения
    /// </summary>
    public string Behavior { get; set; } = string.Empty;

    /// <summary>
    /// Тип питомца (собака, кот)
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Порода
    /// </summary>
    public string Breed { get; set; } = string.Empty;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Медицинская информация
    /// </summary>
    public string MedicalInfo { get; set; } = string.Empty;

    /// <summary>
    /// Фотография питомца
    /// </summary>
    public byte[]? Picture { get; set; }
}
