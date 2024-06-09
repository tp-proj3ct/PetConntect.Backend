using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.Contracts;

/// <summary>
/// Модель бронирования
/// </summary>
public class BookingOutputModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Заказанная услуга
    /// </summary>
    public Service? Service { get; set; }
    public long ServiceId { get; set; }

    /// <summary>
    /// Задействованные питомцы
    /// </summary>
    public List<Pet>? Pets { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime StartedDate { get; set; }

    /// <summary>
    /// Дата окончания
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Адрес выполнения услуги
    /// </summary>
    public string ServiceAddress { get; set; } = string.Empty;

    /// <summary>
    /// Дополнительные условия
    /// </summary>
    public string AdditionalRequirements { get; set; } = string.Empty;

    /// <summary>
    /// Комментарий заказчика
    /// </summary>
    public string CustomerComment { get; set; } = string.Empty;

    /// <summary>
    /// Платеж
    /// </summary>
    public Payment? Payment { get; set; }
}
