using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Infrastructure;
using PetConnect.Backend.UseCases.Commands.Pets;
using PetConnect.Backend.UseCases.Commands.Services;
using PetConnect.Backend.UseCases.Commands.Services.AddServiceCommand;
using PetConnect.Backend.UseCases.Commands.Services.UpdateServiceCommand;
using PetConnect.Backend.UseCases.Commands.User.DeleteUserCommand;
using PetConnect.Backend.UseCases.Queries.Services.GetAllServicesQuery;
using PetConnect.Backend.UseCases.Queries.Services.GetServiceByIdQuery;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для взаимодействия с услуги
/// </summary>
[Authorize(Roles = "PetSitter")]
[Route("api/services")]
[ApiController]
public class ServicesController(IMediator mediator, UserAccessor userAccessor) : ControllerBase
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
    /// Получить все услуги текущего пользователя PetSitter
    /// </summary>
    /// <returns> Массив из питомцев </returns>
    /// <response code="200"></response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(IAsyncEnumerable<ServiceOutputModel>), 200)]
    [ProducesResponseType(400)]
    [HttpGet]
    public IAsyncEnumerable<ServiceOutputModel> GetAllUserServices()
    {
        long userId = _userAccessor.GetUserId();

        return _mediator.CreateStream(new GetAllServicesByUserIdQuery(userId));
    }

    /// <summary>
    /// Получить услугу по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор услуги</param>
    /// <returns> Модель найденной услуги </returns>
    /// <response code="200"> Услуга найдена.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(ServiceOutputModel), 200)]
    [ProducesResponseType(400)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetServiceById(long id)
    {
        var result = await _mediator.Send(new GetServiceByIdQuery(id));
        return result.ToActionResult();
    }

    /// <summary>
    /// Создать новую услугу текущего пользователя PetSitter
    /// </summary>
    /// <param name="model"> Входная модель услуги </param>
    /// <returns> Модель созданной услуги </returns>
    /// <response code="201">Услуга успешно создана.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(Pet), 201)]
    [ProducesResponseType(400)]
    [HttpPost]
    public async Task<IActionResult> CreateUserService([FromBody] ServiceInputModel model)
    {
        long userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new AddServiceCommand(userId, model));
        return result.ToActionResult();

    }

    /// <summary>
    /// Изменить услугу по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор услуги</param>
    /// <param name="model"> Входная модель услуги</param>
    /// <response code="204">Услуга успешно отредактирована.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [HttpPut("{id}")]
    public async Task<IActionResult> EditServiceById(long id, [FromBody] ServiceInputModel model)
    {
        var result = await _mediator.Send(new UpdateServiceCommand(id, model));
        return result.ToActionResult();
    }

    /// <summary>
    /// Удалить услугу по ID
    /// </summary>
    /// <param name="id">Уникальный индетификатор услуги</param>
    /// <response code="204">Услуга успешно удалена.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServiceById(long id)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id));
        return result.ToActionResult();
    }
}
