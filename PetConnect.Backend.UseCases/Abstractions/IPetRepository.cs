using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAll(long id);

    Task<IEnumerable<Pet>> GetAllById(long id);

    Task Add(Pet pet);

    Task Update(Pet pet);

    Task Delete(long id);
}
