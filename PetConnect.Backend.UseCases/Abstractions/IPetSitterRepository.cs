using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IPetSitterRepository
{
    public IEnumerable <PetSitter> GetAll();

    public Task<PetSitter?> GetById(long id);
}
