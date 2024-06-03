using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.UserProfiles.GetUserProfilePictureByIdQuery;

public class GetUserProfilePictureByIdQueryHandler(IUserProfileRepository userProfileRepository) : IRequestHandler<GetUserProfilePictureByIdQuery, Result<byte[]>>
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));

    public async Task<Result<byte[]>> Handle(GetUserProfilePictureByIdQuery request, CancellationToken cancellationToken)
    {
        var userProfile = await _userProfileRepository.GetByUserId(request.UserId);

        if (userProfile is null)
        {
            return Result<byte[]>.Invalid($"User profile to user with Id {request.UserId} doesn't exist!");
        }

        if (userProfile.ProfilePic is null)
        {
            return Result<byte[]>.Invalid($"User profile picture to user with Id {request.UserId} doesn't exist!");
        }

        return Result<byte[]>.Success(userProfile.ProfilePic);
    }
}
