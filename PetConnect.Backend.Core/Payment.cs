namespace PetConnect.Backend.Core;

/// <summary>
/// Платеж
/// </summary>
public class Payment
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Дата оплаты
    /// </summary>
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Бронирование
    /// </summary>
    public long BookingId { get; set; }
    public Booking? Booking { get; set; }
}
