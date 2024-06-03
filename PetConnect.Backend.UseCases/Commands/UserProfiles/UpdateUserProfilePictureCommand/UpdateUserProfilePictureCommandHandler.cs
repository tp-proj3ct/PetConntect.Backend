using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;
using System.Runtime.CompilerServices;

namespace PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfilePictureCommand;

public class UpdateUserProfilePictureCommandHandler(IUserProfileRepository userProfileRepository, IUserRepository userRepository) : IRequestHandler<UpdateUserProfilePictureCommand, Result<Unit>>
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task<Result<Unit>> Handle(UpdateUserProfilePictureCommand request, CancellationToken cancellationToken)
    {
        if (request.Picture == null || request.Picture.Length == 0)
        {
            return Result<Unit>.Invalid("Picture is required.");
        }

        byte[] pictureBytes;
        using (var memoryStream = new MemoryStream())
        {
            await request.Picture.CopyToAsync(memoryStream, cancellationToken);
            pictureBytes = memoryStream.ToArray();
        }

        var user = await _userRepository.GetById(request.UserId);

        if (user is null)
        {
            return Result<Unit>.Invalid($"User with Id {request.UserId} not found");
        }

        var userProfile = await _userProfileRepository.GetByUserId(request.UserId);

        if (userProfile is null)
        {
            return Result<Unit>.Invalid($"User profile to user with Id {request.UserId} doesn't exist!");
        }

        userProfile.ProfilePic = pictureBytes;
        await _userProfileRepository.Update(userProfile);

        return Result<Unit>.Empty();
    }
}
