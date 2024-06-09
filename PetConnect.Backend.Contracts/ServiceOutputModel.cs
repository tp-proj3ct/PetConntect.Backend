namespace PetConnect.Backend.Contracts;

/// <summary>
/// Модель услуг
/// </summary>
public class ServiceOutputModel
{
    /// <summary>
    /// Индетификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; }
}
