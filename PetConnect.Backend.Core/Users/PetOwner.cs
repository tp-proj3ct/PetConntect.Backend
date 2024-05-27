using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core.Users;

public class PetOwner : User
{
    public Pet[]? Pets { get; set; }
    public Review[]? Reviews { get; set; }
}
