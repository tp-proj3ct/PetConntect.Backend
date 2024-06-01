using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IUserProfileRepository
{
    public Task<UserProfile?> GetById(long id);

    public Task<UserProfile?> GetByUserId(long userId);

    public Task Add(UserProfile userProfile);
    public Task Update(UserProfile userProfile);
}
