using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

/// <summary>
/// Реализация <see cref="IBookingRepository"/>.
/// </summary>
public class BookingRepository(Context context) : IBookingRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc/>
    public IAsyncEnumerable<Booking> GetAllByPetSitterId(long petSitterId)
    {
        return _context.Bookings
                       .Include(b => b.Service)
                       .Where(b => b.Service!.PetSitterId == petSitterId)
                       .Include(b => b.Pets)
                       .Include(b => b.Payment)
                       .AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<Booking> GetAllByPetOwnerId(long petOwnerId)
    {
        return _context.Bookings
                       .Where(b => b.CustomerId == petOwnerId)
                       .Include(b => b.Service)
                       .Include(b => b.Pets)
                       .Include(b => b.Payment)
                       .AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public async Task Add(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();

    }
}
