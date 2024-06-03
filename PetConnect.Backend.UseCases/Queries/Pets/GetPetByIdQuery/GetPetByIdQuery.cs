using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Pets.GetPetByIdQuery;

public record GetPetByIdQuery(long PetId) : IRequest<Result<PetOutputModel>>;
