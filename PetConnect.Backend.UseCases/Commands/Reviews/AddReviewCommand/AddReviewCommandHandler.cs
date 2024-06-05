
using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Reviews.AddReviewCommand;

public class AddReviewCommandHandler(IUserRepository userRepository, IReviewRepository reviewRepository, IMapper mapper) : IRequestHandler<AddReviewCommand, Result<ReviewOutputModel>>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IReviewRepository _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Result<ReviewOutputModel>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        var existingTargetUser = await _userRepository.GetById(request.TargetId);
        if (existingTargetUser is null) return Result<ReviewOutputModel>.Invalid($"Target user with id {request.TargetId} doesnt exist!");

        var existingReviewerUser = await _userRepository.GetById(request.ReviewerId);
        if (existingReviewerUser is null) return Result<ReviewOutputModel>.Invalid($"Reviewer user with id {request.ReviewerId} doesnt exist!");

        // TODO проверять если у пользователя завершенное бронирование для оставления отзыва

        var review = _mapper.Map<Review>(request.Model);
        review.TargetId = request.TargetId;
        review.ReviewerId = request.ReviewerId;

        await _reviewRepository.Add(review);

        return Result<ReviewOutputModel>.SuccessfullyCreated(_mapper.Map<ReviewOutputModel>(review));

    }
}
    