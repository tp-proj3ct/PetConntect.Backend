using PetConnect.Backend.Core.Services;
using PetConnect.Backend.Core.Options;

namespace PetConnect.Backend.Core.Abstractions;

public abstract class User
{
    public long Id { get; set; }

    public string Login { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public Role Role { get; set; } = Role.None;

    public bool IsBlocked { get; set; } = false;

    public void SetPassword(string password, PasswordOptions passwordOptions)
    {
        PasswordHash = CryptographyService.HashPassword(password, passwordOptions.Salt);
    }
}
