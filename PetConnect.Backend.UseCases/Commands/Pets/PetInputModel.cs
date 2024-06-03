using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.UseCases.Commands.Pets;
/// <summary>
/// Модель ввода для создания питомца.
/// </summary>
public class PetInputModel
{
    /// <summary>
    /// Имя питомца.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Возраст питомца
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Вес питомца
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// Пол питомца
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Поведение питомца
    /// </summary>
    public string Behavior { get; set; }

    /// <summary>
    /// Тип питомца (собака, кошка и т.д)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Порода питомца
    /// </summary>
    public string Breed { get; set; }

    /// <summary>
    /// Описание питомца
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Медицинская информация о питомце
    /// </summary>
    public string MedicalInfo { get; set; }
}
