using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Queries.UserProfiles.GetUserProfileByIdQuery;

public class GetUserProfileByUserIdQueryHandler(IUserProfileRepository userProfileRepository) : IRequestHandler<GetUserProfileByUserIdQuery, Result<UserProfile>>
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));

    public async Task<Result<UserProfile>> Handle(GetUserProfileByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userProfile = await _userProfileRepository.GetByUserId(request.Id);

        if (userProfile is null)
        {
            return Result<UserProfile>.Invalid($"User profile to user with Id {request.Id} doesn't exist!");
        }

        return Result<UserProfile>.Success(userProfile);
    }
}
