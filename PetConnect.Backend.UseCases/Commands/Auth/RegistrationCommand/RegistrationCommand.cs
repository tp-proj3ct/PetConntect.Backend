using MediatR;

using PetConnect.Backend.Core.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;

public class RegistrationCommand : IRequest<Result<Unit>>
{
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public Role Role { get; set; }
}
