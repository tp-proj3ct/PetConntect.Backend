using MediatR;
using Microsoft.AspNetCore.Http;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfilePictureCommand;

public record class UpdateUserProfilePictureCommand(long UserId, IFormFile Picture) : IRequest<Result<Unit>>;