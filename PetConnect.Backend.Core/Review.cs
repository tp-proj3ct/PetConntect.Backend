using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.Core;

/// <summary>
/// Отзыв
/// </summary>
public class Review
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
    public string Comment { get; set; } = string.Empty;
    
    /// <summary>
    /// Заказчик
    /// </summary>
    public PetOwner? Reviewer { get; set; }
    public long ReviewerId { get; set; }

    /// <summary>
    /// Сиделка
    /// </summary>
    public PetSitter? Target { get; set; }
    public long TargetId { get; set; }
}
