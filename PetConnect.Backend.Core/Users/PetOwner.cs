using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core.Users;

public class PetOwner : User
{
    public ICollection<Pet>? Pets { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}
