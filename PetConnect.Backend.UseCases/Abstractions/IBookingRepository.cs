using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IBookingRepository
{
    IAsyncEnumerable<Booking> GetAll();
}
