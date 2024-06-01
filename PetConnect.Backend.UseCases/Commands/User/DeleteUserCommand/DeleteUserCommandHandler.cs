using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.User.DeleteUserCommand;

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Result<Unit>>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);
        if (user == null)
        {
            return Result<Unit>.Invalid($"User with {request.Id} doesn't exist");
        }

        await _userRepository.Delete(user);

        return Result<Unit>.Empty();
    }
}