using MediatR;
using PetConnect.Backend.Contracts;

namespace PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsByPetOwnerIdQuery;

public record class GetAllReviewsByPetOwnerIdQuery(long PetOwnerId) : IStreamRequest<ReviewOutputModel>;

