using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core;

public class User
{
    public long Id { get; set; }

    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Role Role { get; set; } 

    public UserProfile Profile { get; set; }
    public long UserProfileId { get; set; }

}
