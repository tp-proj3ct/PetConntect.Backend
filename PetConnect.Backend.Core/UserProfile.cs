namespace PetConnect.Backend.Core;

public class UserProfile
{
    public long Id { get; set; }

    public User User { get; set; }
    public long UserId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public byte[]? ProfilePic { get; set; }

    public Pet[]? Pets { get; set; }

    public string GetFullName()
    {
        return $"{Name} {Surname}";
    }
}
