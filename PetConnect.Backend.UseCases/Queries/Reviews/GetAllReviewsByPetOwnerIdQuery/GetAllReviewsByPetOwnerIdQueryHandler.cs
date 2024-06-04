using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsByPetOwnerIdQuery;

public class GetAllReviewsByPetOwnerIdQueryHandler(IReviewRepository reviewRepository,
                                                    IUserRepository userRepository,
                                                    IMapper mapper) : IStreamRequestHandler<GetAllReviewsByPetOwnerIdQuery, ReviewOutputModel>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IReviewRepository _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async IAsyncEnumerable<ReviewOutputModel> Handle(GetAllReviewsByPetOwnerIdQuery request, CancellationToken _)
    {
        var user = await _userRepository.GetById(request.PetOwnerId);

        if (user is not null)
        {
            await foreach (var review in _reviewRepository.GetAllByPetOwnerId(request.PetOwnerId))
            {
                yield return _mapper.Map<ReviewOutputModel>(review);
            }
        }
    }
}
