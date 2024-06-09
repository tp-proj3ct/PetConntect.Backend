using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Dto;

/// <summary>
/// Промежуточная таблица
/// </summary>
public class BookingPetsDto
{
    /// <summary>
    /// Бронироваие
    /// </summary>
    public long BookingId { get; set; }
    public Booking? Booking { get; set; }

    /// <summary>
    /// Питомец
    /// </summary>
    public long PetId { get; set; }
    public Pet? Pet { get; set; }
}
