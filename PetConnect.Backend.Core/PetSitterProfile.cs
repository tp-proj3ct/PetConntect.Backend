namespace PetConnect.Backend.Core;

public class PetSitterProfile
{
    public long Id { get; set; }
    public UserProfile UserProfile { get; set; }
    public long UserProfileId { get; set; }

    public string Comment { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int ExpeirenceYears { get; set; }

    public Service[]? Services { get; set; }
    public Review[]? Reviews { get; set; }

}
