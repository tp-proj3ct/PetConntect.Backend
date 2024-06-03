using MediatR;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.UserProfiles.GetUserProfilePictureByIdQuery;

public record class GetUserProfilePictureByIdQuery(long UserId) : IRequest<Result<byte[]>>;
