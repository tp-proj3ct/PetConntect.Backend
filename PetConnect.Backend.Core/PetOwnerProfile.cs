namespace PetConnect.Backend.Core;

public class PetOwnerProfile
{
    public long Id { get; set; }
    public UserProfile UserProfile { get; set; }
    public long UserProfileId { get; set; }

    public Pet[]? Pets { get; set; }
}
