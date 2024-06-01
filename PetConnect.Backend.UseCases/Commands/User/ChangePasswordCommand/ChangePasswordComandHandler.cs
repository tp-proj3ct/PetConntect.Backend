using MediatR;
using Microsoft.Extensions.Options;
using PetConnect.Backend.Core.Options;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;
using System.ComponentModel.DataAnnotations;

namespace PetConnect.Backend.UseCases.Commands.User.ChangePasswordCommand;

public class ChangePasswordComandHandler(IUserRepository userRepository,
                                        IOptions<PasswordOptions> passwordOptions) : IRequestHandler<ChangePasswordCommand, Result<Unit>>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly PasswordOptions _passwordOptions = passwordOptions?.Value ?? throw new ArgumentNullException(nameof(passwordOptions));


    public async Task<Result<Unit>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        if (!Validator.TryValidateObject(request, new ValidationContext(request), null, true))
        {
            return Result<Unit>.Invalid("Invalid password format!");
        }

        var user = await _userRepository.GetById(request.UserId);
        if (user == null)
        {
            return Result<Unit>.Invalid($"User with {request.UserId} doesn't exist");
        }

        await _userRepository.ChangePassword(user, request.Password, _passwordOptions);

        return Result<Unit>.Empty();
    }
}
