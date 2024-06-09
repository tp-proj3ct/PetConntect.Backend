using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.Contracts;

/// <summary>
/// Модель бронирования для сиделки
/// <inheritdoc/>
/// </summary>
public class BookingForPetSitterOutputModel : BookingOutputModel
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public PetOwner? Customer { get; set; }
    public long CustomerId { get; set; }
}
