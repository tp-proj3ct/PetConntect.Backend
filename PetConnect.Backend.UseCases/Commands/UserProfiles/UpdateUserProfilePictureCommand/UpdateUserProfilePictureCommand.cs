using MediatR;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfilePictureCommand;

public class UpdateUserProfilePictureCommand(long id, byte[] profilePic) : IRequest<Result<Unit>>
{
    public long Id { get; set; } = id;
}
