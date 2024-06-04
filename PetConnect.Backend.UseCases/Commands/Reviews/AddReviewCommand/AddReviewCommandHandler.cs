
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Reviews.AddReviewCommand;

public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Result<ReviewOutputModel>>
{
    public Task<Result<ReviewOutputModel>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        // TODO проверять если у пользователя завершенное бронирование для оставления отзыва
    }
}
