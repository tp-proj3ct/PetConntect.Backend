using MediatR;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Commands.Auth.LoginCommand;

public class LoginCommand : IRequest<Result<string>>
{
    public string Login { get; set; }
    public string Password { get; set; }
}
