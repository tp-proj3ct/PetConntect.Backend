using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Pets.CreatePetCommand;

public record class CreatePetCommand(long UserId, PetInputModel Model) : IRequest<Result<PetOutputModel>>;


