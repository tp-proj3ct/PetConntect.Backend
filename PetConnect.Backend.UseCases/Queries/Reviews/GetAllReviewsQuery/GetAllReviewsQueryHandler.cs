using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsQuery;

public class GetAllReviewsQueryHandler(IReviewRepository reviewRepository) : IStreamRequestHandler<GetAllReviewsQuery, Review>
{
    private readonly IReviewRepository _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));

    public IAsyncEnumerable<Review> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        return _reviewRepository.GetAll();
    }
}
