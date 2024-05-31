using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

public class UserProfileRepository(Context context) : IUserProfileRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<UserProfile?> GetById(long id)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(up => up.Id == id);
    }

    public async Task<UserProfile?> GetByUserId(long userId)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(up => up.UserId == userId);
    }

    public async Task Add(UserProfile userProfile)
    {
        await _context.AddAsync(userProfile);
        await _context.SaveChangesAsync();
    }

    public async Task Update(UserProfile userProfile)
    {
        _context.Update(userProfile);
        await _context.SaveChangesAsync();
    }
}
