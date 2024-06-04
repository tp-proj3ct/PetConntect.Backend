using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;
namespace PetConnect.Backend.UseCases.Queries.PetSitters.GetAllPetSittersQuery;

public record GetAllPetSittersQuery : IRequest<Result<IEnumerable<PetSitterOutputModel>>>;
