using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfileCommand;

public class UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IUserRepository userRepository) : IRequestHandler<UpdateUserProfileCommand, Result<Unit>>
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task<Result<Unit>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetById(request.UserId);

        if (existingUser is null)
        {
            return Result<Unit>.Invalid($"User with Id {request.UserId} not found");
        }

        var existingUserProfile = await _userProfileRepository.GetByUserId(request.UserId);

        if (existingUserProfile is null) 
        {
            return Result<Unit>.Invalid($"User profile to user with Id {request.UserId} doesn't exist!");
        }

        existingUserProfile.Name = request.Model.Name;
        existingUserProfile.Surname = request.Model.Surname;

        await _userProfileRepository.Update(existingUserProfile);

        return Result<Unit>.Empty();
    }
}
