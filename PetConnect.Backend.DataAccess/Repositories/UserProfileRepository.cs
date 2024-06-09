using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

/// <summary>
/// Реализация <see cref="IUserProfileRepository"/>.
/// </summary>
public class UserProfileRepository(Context context) : IUserProfileRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc/>
    public async Task<UserProfile?> GetById(long id)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(up => up.Id == id);
    }

    /// <inheritdoc/>
    public async Task<UserProfile?> GetByUserId(long userId)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(up => up.UserId == userId);
    }

    /// <inheritdoc/>
    public async Task Add(UserProfile userProfile)
    {
        await _context.AddAsync(userProfile);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Update(UserProfile userProfile)
    {
        _context.Update(userProfile);
        await _context.SaveChangesAsync();
    }
}
