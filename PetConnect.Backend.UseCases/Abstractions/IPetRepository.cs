using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IPetRepository
{
    IAsyncEnumerable<Pet> GetAll();

    IAsyncEnumerable<Pet> GetAllByUserId(long userId);

    Task<Pet?> GetById(long petId);

    Task Add(Pet pet);

    Task Update(Pet pet);

    Task Delete(Pet pet);
}
