using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

using PasswordOptions = Core.Options.PasswordOptions;

/// <summary>
/// Реализация <see cref="IUserRepository"/>.
/// </summary>
public class UserRepository(Context context) : IUserRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc/>
    public IAsyncEnumerable<User> GetAll()
    {
        return _context.Users
               .AsNoTracking()
               .AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public async Task<User?> Resolve(string login, string password)
    {
        return await _context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(u => u.Login == login && u.PasswordHash == password);
                                
    }

    /// <inheritdoc/>
    public async Task<User?> GetById(long id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    /// <inheritdoc/>
    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    /// <inheritdoc/>
    public async Task<User?> GetByLogin(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
    }

    /// <inheritdoc/>
    public async Task ChangeEmail(User user, string email)
    {
        user.Email = email;
        await _context.SaveChangesAsync();
        
    }

    /// <inheritdoc/>
    public async Task ChangePassword(User user, string password, PasswordOptions passwordOptions)
    {
        user.SetPassword(password, passwordOptions); 
        await _context.SaveChangesAsync();
        
    }

    /// <inheritdoc/>
    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
    }

}
