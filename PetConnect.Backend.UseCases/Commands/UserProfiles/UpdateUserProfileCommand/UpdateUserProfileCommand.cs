using MediatR;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfileCommand;

public class UpdateUserProfileCommand (long userId, UserProfileInputModel model) : IRequest<Result<Unit>>
{
    public long UserId { get; set; } = userId;
    public UserProfileInputModel Model { get; set; } = model;
}
