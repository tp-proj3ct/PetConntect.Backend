using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface ITokenService
{
    public string GenerateToken(User user);
}
