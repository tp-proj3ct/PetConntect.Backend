using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Queries.UserProfiles.GetUserProfileByIdQuery;

public class GetUserProfileByUserIdQuery(long id) : IRequest<Result<UserProfile>>
{
    public long Id { get; set; } = id;
}
