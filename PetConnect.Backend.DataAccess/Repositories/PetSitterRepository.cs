using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core.Users;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

/// <summary>
/// Реализация <see cref="IPetSitterRepository"/>.
/// </summary>
public class PetSitterRepository(Context context) : IPetSitterRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc/>
    public IEnumerable<PetSitter> GetAll()
    {
        return _context.PetSitters.ToList();
    }

    /// <inheritdoc/>
    public async Task<PetSitter?> GetById(long id)
    {
        return await _context.PetSitters
            .FirstOrDefaultAsync(ps => ps.Id == id);
    }
}
