using MediatR;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsQuery;

public class GetAllReviewsQuery : IStreamRequest<Review>;

