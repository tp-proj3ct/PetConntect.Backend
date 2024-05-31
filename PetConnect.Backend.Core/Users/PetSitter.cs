using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core.Users;

public class PetSitter : User
{
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int ExperienceYears { get; set; }

    public ICollection<Service> Services { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
