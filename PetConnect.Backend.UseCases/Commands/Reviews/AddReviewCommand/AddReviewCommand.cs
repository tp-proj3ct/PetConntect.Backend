using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Reviews.AddReviewCommand;

public record AddReviewCommand(long ReviewerId, long TargedId, ReviewInputModel Model) : IRequest<Result<ReviewOutputModel>>;
