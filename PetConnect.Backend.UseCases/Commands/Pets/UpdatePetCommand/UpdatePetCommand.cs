using MediatR;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Pets.UpdatePetCommand;

public record UpdatePetCommand(long PetId, PetInputModel Model) : IRequest<Result<Unit>>;

