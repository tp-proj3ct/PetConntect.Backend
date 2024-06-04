using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Infrastructure;
using PetConnect.Backend.UseCases.Commands.Reviews;
using PetConnect.Backend.UseCases.Queries.Pets.GetAllPetsByUserIdQuery;
using PetConnect.Backend.UseCases.Queries.PetSitters.GetAllPetSittersQuery;
using PetConnect.Backend.UseCases.Queries.PetSitters.GetPetSitterByIdQuery;
using PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsByPetSitterIdQuery;
using PetConnect.Backend.UseCases.Queries.Services.GetAllServicesQuery;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.Service.Controllers;

using Service = Core.Service;

[Route("api/pet-sitters")]
[AllowAnonymous]
[ApiController]
public class PetSittersController(IMediator mediator, UserAccessor userAccessor) : ControllerBase
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
    /// Получить всех PetSitter
    /// </summary>
    /// <returns> Массив из отзывов </returns>
    /// <response code="200"> Отзывы найдены.</response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<PetSitterOutputModel>), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAllPetSitters()
    {
       var result = await _mediator.Send(new GetAllPetSittersQuery());
       return result.ToActionResult();
    }

    /// <summary>
    /// Получить все отзывы конкретного PetSitter
    /// </summary>
    /// <returns> Массив из отзывов </returns>
    /// <response code="200"> Отзывы найдены.</response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PetSitterOutputModel), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetPetSitterById(long id)
    {
        var result = await _mediator.Send(new GetPetSitterByIdQuery(id));
        return result.ToActionResult();
    }

    /// <summary>
    /// Получить все отзывы конкретного PetSitter
    /// </summary>
    /// <returns> Массив из отзывов </returns>
    /// <response code="200"> Отзывы найдены. Возвращает отызывы. </response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("{id}/reviews")]
    [ProducesResponseType(typeof(IAsyncEnumerable<ReviewOutputModel>), 200)]
    [ProducesResponseType(400)]
    public IAsyncEnumerable<ReviewOutputModel> GetAllPetSitterReviews(long id)
    {
        return _mediator.CreateStream(new GetAllReviewsByPetSitterIdQuery(id));
    }

    /// <summary>
    /// Получить все услуги конкретного PetSitter
    /// </summary>
    /// <returns> Массив из услуг </returns>
    /// <response code="200"> Услуги найдены. Возвращает отзывы. </response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("{id}/services")]
    [ProducesResponseType(typeof(IAsyncEnumerable<ServiceOutputModel>), 200)]
    [ProducesResponseType(400)]
    public IAsyncEnumerable<ServiceOutputModel> GetAllPetSitterServices(long id)
    {
        return _mediator.CreateStream(new GetAllServicesByUserIdQuery(id));
    }

    /// <summary>
    /// Добавить отзыв для конкретного PetSitter
    /// </summary>
    /// <response code="201"> Услугу успешно создана. Возвращает созданную услугу </response>
    /// <response code="400">Некорректный запрос.</response>
    [Authorize(Roles = "PetOwner")]
    [HttpPost("{id}/reviews")]
    [ProducesResponseType(typeof(ReviewOutputModel), 201)]
    [ProducesResponseType(400)]
    public Task<IActionResult> AddReview(ReviewInputModel model, long id)
    {
        long userId = userAccessor.GetUserId();

        throw new NotImplementedException();
    }
}
