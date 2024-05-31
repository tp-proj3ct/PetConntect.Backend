using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IUserAccessor 
{
    public long GetUserId();
    public string GetUsername();
    public Role GetRole();
}
