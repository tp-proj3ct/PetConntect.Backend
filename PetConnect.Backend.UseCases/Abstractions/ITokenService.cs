using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface ITokenService
{
    public Token GenerateToken(User user);
}
