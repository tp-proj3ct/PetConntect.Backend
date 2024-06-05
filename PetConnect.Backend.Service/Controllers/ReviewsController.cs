using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Infrastructure;
using PetConnect.Backend.UseCases.Commands.Reviews;
using PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsByPetOwnerIdQuery;
using PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsByPetSitterIdQuery;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для взаимодействия с отзывами текующего пользователя
/// </summary>
/// <param name="mediator"></param>
/// <param name="userAccessor"></param>
[Authorize(Roles = "PetOwner, PetSitter")]
[Route("api/reviews")]
[ApiController]
public class ReviewsController(IMediator mediator, UserAccessor userAccessor) : ControllerBase
{
    /// <summary>
    /// Посредник
    /// </summary>
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// Сервис для доступа к данным пользователя
    /// </summary>
    private readonly UserAccessor _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));

    /// <summary>
    /// Получить все отзывы текующего пользователя
    /// </summary>
    /// <response code="200"> Отзывы найдены. Возвращает отызывы. </response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(IAsyncEnumerable<ReviewOutputModel>), 200)]
    [ProducesResponseType(400)]
    [HttpGet]
    public IAsyncEnumerable<ReviewOutputModel> GetAllUserReviews()
    {
        Role role = _userAccessor.GetRole();
        long userId = _userAccessor.GetUserId();

        switch (role)
        {
            case Role.PetSitter:
                return _mediator.CreateStream(new GetAllReviewsByPetSitterIdQuery(userId));

            case Role.PetOwner:
                return _mediator.CreateStream(new GetAllReviewsByPetOwnerIdQuery(userId));

            default:
                return AsyncEnumerable.Empty<ReviewOutputModel>();
        }
    }
}