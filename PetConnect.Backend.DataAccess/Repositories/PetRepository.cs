using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

/// <summary>
/// Реализация <see cref="IPetRepository"/>.
/// </summary>
public class PetRepository(Context context) : IPetRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc/>
    public IAsyncEnumerable<Pet> GetAll()
    {
        return  _context.Pets.AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<Pet> GetAllByUserId(long userId)
    {
        return _context.Pets.Where(p => p.PetOwnerId == userId).AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public async Task<Pet?> GetById(long petId)
    {
        return await _context.Pets.FirstOrDefaultAsync(p => p.Id == petId);
    }

    /// <inheritdoc/>
    public async Task Add(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Update(Pet pet)
    {
        _context.Update(pet);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async  Task Delete(Pet pet)
    {
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
    }
}
