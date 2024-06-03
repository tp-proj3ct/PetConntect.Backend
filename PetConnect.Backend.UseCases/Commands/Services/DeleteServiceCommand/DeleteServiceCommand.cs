using MediatR;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Commands.Services.DeleteServiceCommand;

public record DeleteServiceCommand(long ServiceId) : IRequest<Result<Unit>>;