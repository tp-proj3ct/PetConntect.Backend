using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Core;
using PetConnect.Backend.Infrastructure;
using PetConnect.Backend.UseCases.Commands.Pets;

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
    [ProducesResponseType(typeof(IAsyncEnumerable<Pet>), 200)]
    [ProducesResponseType(400)]
    [HttpGet]
    public async Task<IActionResult> GetAllUserServices()
    {
        long userId = _userAccessor.GetUserId();

        throw new NotImplementedException();
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
    public async Task<IActionResult> CreateUserService([FromBody] PetInputModel model)
    {
        long userId = _userAccessor.GetUserId();

        throw new NotImplementedException();

    }

    /// <summary>
    /// Получить услугу по ID
    /// </summary>
    /// <param name="serviceId"> Уникальный индетификатор услуги</param>
    /// <returns> Модель найденной услуги </returns>
    /// <response code="200"> Услуга найдена.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(Pet), 200)]
    [ProducesResponseType(400)]
    [HttpGet("{serviceId}")]
    public async Task<IActionResult> GetServiceById(long serviceId)
    {

        throw new NotImplementedException();
    }

    /// <summary>
    /// Изменить услугу по ID
    /// </summary>
    /// <param name="serviceId"> Уникальный индетификатор услуги</param>
    /// <param name="model"> Входная модель услуги</param>
    /// <response code="204">Услуга успешно отредактирована.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [HttpPut("{serviceId}")]
    public async Task<IActionResult> EditServiceById(long serviceId, [FromBody] PetInputModel model)
    {

        throw new NotImplementedException();
    }

    /// <summary>
    /// Удалить услугу по ID
    /// </summary>
    /// <param name="serviceId">Уникальный индетификатор услуги</param>
    /// <response code="204">Услуга успешно удалена.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpDelete("{serviceId}")]
    public async Task<IActionResult> DeleteServiceById(long serviceId)
    {
        throw new NotImplementedException();
    }
}
