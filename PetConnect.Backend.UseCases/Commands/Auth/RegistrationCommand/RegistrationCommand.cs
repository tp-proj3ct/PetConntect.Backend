using MediatR;

using PetConnect.Backend.Core.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;

public record class RegistrationCommand (string Login, string Password, string Email, string Role) : IRequest<Result<Unit>>;
