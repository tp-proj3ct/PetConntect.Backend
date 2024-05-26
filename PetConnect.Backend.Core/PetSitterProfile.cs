namespace PetConnect.Backend.Core;

public class PetSitterProfile
{
    public long Id { get; set; }
    public UserProfile UserProfile { get; set; }
    public long UserProfileId { get; set; }

    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int ExperienceYears { get; set; }

    public Service[]? Services { get; set; }
    public Review[]? Reviews { get; set; }

}
