using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;


namespace PetConnect.Backend.DataAccess.Repositories;


public class BookingRepository(Context context) : IBookingRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    public IAsyncEnumerable<Booking> GetAll()
    {
        return _context.Bookings.AsAsyncEnumerable();
    }
}
