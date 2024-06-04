using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core.Users;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

public class PetSitterRepository(Context context) : IPetSitterRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    public IEnumerable<PetSitter> GetAll()
    {
        return _context.PetSitters.ToList();
    }

    public async Task<PetSitter?> GetById(long id)
    {
        return await _context.PetSitters
            .FirstOrDefaultAsync(ps => ps.Id == id);
    }
}
