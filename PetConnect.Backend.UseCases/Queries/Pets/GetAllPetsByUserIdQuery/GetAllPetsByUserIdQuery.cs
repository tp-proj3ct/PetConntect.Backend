using MediatR;
using PetConnect.Backend.Contracts;

namespace PetConnect.Backend.UseCases.Queries.Pets.GetAllPetsByUserIdQuery;

public record GetAllPetsByUserIdQuery(long UserId) : IStreamRequest<PetOutputModel>;

