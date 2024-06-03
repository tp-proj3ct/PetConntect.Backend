using MediatR;
using Microsoft.AspNetCore.Http;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Pets.UpdatePetImageCommand;

public record UpdatePetImageCommand (long PetId, IFormFile Picture) : IRequest<Result<byte[]>>;
