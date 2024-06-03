using MediatR;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Pets.GetPetImageByIdQuery;

public record GetPetImageByIdQuery(long PetId): IRequest<Result<byte[]>>;
