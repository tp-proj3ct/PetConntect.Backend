using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.UseCases.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsByPetSitterIdQuery;

public class GetAllReviewsByPetSitterIdQueryHandler(IReviewRepository reviewRepository, 
                                                    IUserRepository userRepository,
                                                    IMapper mapper) : IStreamRequestHandler<GetAllReviewsByPetSitterIdQuery, ReviewOutputModel>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IReviewRepository _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async IAsyncEnumerable<ReviewOutputModel> Handle(GetAllReviewsByPetSitterIdQuery request, CancellationToken _)
    {
        var user = await _userRepository.GetById(request.PetSitterId);

        if (user is not null)
        {
            await foreach (var review in _reviewRepository.GetAllByPetSitterId(request.PetSitterId))
            {
                yield return _mapper.Map<ReviewOutputModel>(review);
            }
        }
    }
}
