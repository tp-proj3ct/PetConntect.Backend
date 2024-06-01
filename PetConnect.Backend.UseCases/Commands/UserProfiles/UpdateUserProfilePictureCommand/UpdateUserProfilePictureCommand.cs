using MediatR;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfilePictureCommand;

public class UpdateUserProfilePictureCommand(long userId, byte[] profilePic) : IRequest<Result<Unit>>
{
    public long UserId { get; set; } = userId;
    public byte[] ProfilePic { get; set; } = profilePic;
}
