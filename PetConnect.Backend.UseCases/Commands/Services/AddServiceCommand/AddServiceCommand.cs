using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Services.AddServiceCommand;

public record AddServiceCommand(long UserId, ServiceInputModel Model) : IRequest<Result<Service>>;
