using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using System.Collections.Generic;

namespace PetConnect.Backend.DataAccess.Repositories;

public class PetRepository(Context context) : IPetRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));


    public IAsyncEnumerable<Pet> GetAll()
    {
        return  _context.Pets.AsAsyncEnumerable();
    }

    public IAsyncEnumerable<Pet> GetAllByUserId(long userId)
    {
        return _context.Pets.Where(p => p.PetOwnerId == userId).AsAsyncEnumerable();
    }
    
    public async Task<Pet?> GetById(long petId)
    {
        return await _context.Pets.FirstOrDefaultAsync(p => p.Id == petId);
    }

    public async Task Add(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Pet pet)
    {
        _context.Update(pet);
        await _context.SaveChangesAsync();
    }

    public async  Task Delete(Pet pet)
    {
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
    }
}
