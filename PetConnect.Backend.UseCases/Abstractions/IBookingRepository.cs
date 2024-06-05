using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IBookingRepository
{
    IAsyncEnumerable<Booking> GetAllByPetSitterId(long petSitterId);
    IAsyncEnumerable<Booking> GetAllByPetOwnerId(long petOwnerId);

    Task Add(Booking booking);
}
