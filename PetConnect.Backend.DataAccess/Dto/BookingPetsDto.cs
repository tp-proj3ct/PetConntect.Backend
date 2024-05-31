using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Dto;

public class BookingPetsDto
{
    public long BookingId { get; set; }
    public Booking Booking { get; set; }

    public long PetId { get; set; }
    public Pet Pet { get; set; }
}
