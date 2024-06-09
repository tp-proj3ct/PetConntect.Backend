namespace PetConnect.Backend.Contracts;

public class PetOutputModel
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
    public string Gender { get; set; } = string.Empty;

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
}
