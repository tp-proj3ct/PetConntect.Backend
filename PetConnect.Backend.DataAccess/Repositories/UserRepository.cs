using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

public class UserRepository(Context context) : IUserRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    public IAsyncEnumerable<User> GetAll()
    {
        return _context.Users
               .AsNoTracking()
               .AsAsyncEnumerable();
    }
    public async Task<User?> Resolve(string login, string password)
    {
        return await _context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(u => u.Login == login && u.PasswordHash == password);
                                
    }

    public async Task<User?> GetById(long id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
    
    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<User?> GetByLogin(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

}
