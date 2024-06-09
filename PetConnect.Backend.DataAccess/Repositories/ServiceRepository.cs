using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

/// <summary>
/// Реализация <see cref="IServiceRepository"/>.
/// </summary>
public class ServiceRepository(Context context) : IServiceRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc/>
    public IAsyncEnumerable<Service> GetAll()
    {
        return _context.Services.AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<Service> GetAllByUserId(long userId)
    {
        return _context.Services.Where(s => s.PetSitterId == userId).AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public async Task<Service?> GetById(long serviceId)
    {
        return await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);
    }

    /// <inheritdoc/>
    public async Task Add(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Update(Service service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Delete(Service service)
    {
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
    }
}
