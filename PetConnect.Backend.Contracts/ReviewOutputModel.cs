namespace PetConnect.Backend.Contracts;

/// <summary>
/// Модель отзыва
/// </summary>
public class ReviewOutputModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Оценка
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? Comment { get; set; }
}
