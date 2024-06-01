using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;
using System.ComponentModel.DataAnnotations;

namespace PetConnect.Backend.UseCases.Commands.User.ChangeEmailCommand;

public class ChangeEmailCommandHandler(IUserRepository userRepository) : IRequestHandler<ChangeEmailCommand, Result<Unit>>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task<Result<Unit>> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        if (!Validator.TryValidateObject(request, new ValidationContext(request), null, true))
        {
            return Result<Unit>.Invalid("Invalid request");
        }

        var user = await _userRepository.GetById(request.UserId);

        if (user == null)
        {
            return Result<Unit>.Invalid($"User with {request.UserId} doesn't exist");
        }

        await _userRepository.ChangeEmail(user, request.Email);

        return Result<Unit>.Empty();
    }
}
