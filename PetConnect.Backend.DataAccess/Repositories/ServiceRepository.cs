using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

public class ServiceRepository(Context context) : IServiceRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    public IAsyncEnumerable<Service> GetAll()
    {
        return _context.Services.AsAsyncEnumerable();
    }

    public IAsyncEnumerable<Service> GetAllByUserId(long userId)
    {
        return _context.Services.Where(s => s.PetSitterId == userId).AsAsyncEnumerable();
    }

    public async Task<Service?> GetById(long serviceId)
    {
        return await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);
    }

    public async Task Add(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Service service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Service service)
    {
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
    }
}
