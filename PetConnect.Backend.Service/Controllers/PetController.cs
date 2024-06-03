using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.Infrastructure;
using PetConnect.Packages.UseCases;
using PetConnect.Backend.UseCases.Commands.Pets;
using PetConnect.Backend.UseCases.Commands.Pets.CreatePetCommand;
using PetConnect.Backend.UseCases.Queries.Pets.GetAllPetsByUserIdQuery;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Commands.Pets.UpdatePetCommand;
using PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;
using PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfileCommand;
using PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfilePictureCommand;
using PetConnect.Backend.UseCases.Commands.Pets.DeletePetCommand;
using PetConnect.Backend.UseCases.Queries.Pets.GetPetByIdQuery;
using PetConnect.Backend.UseCases.Queries.Pets.GetPetImageByIdQuery;
using PetConnect.Backend.UseCases.Commands.Pets.UpdatePetImageCommand;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для работы с животными
/// </summary>
[Authorize(Roles = "PetOwner")]
[Route("api/pets")]
[ApiController]
public class PetsController(IMediator mediator, UserAccessor userAccessor) : ControllerBase
{
    /// <summary>
    /// Посредник
    /// </summary>
    private readonly IMediator _mediator =  mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// Сервис для доступа к данным пользователя
    /// </summary>
    private readonly UserAccessor _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));

    /// <summary>
    /// Получить всех питомцев текущего пользователя PetOwner
    /// </summary>
    /// <returns> Массив из питомцев </returns>
    /// <response code="200"></response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(IAsyncEnumerable<PetOutputModel>), 200)]
    [ProducesResponseType(400)]
    [HttpGet]
    public IAsyncEnumerable<PetOutputModel> GetAllUserPets()
    {
        long userId = _userAccessor.GetUserId();

        return _mediator.CreateStream(new GetAllPetsByUserIdQuery(userId));
    }

    /// <summary>
    /// Создать нового питомца текущего пользователя PetOwner
    /// </summary>
    /// <param name="model"> Входная модель питомца </param>
    /// <returns> Модель созданного питомца питомца </returns>
    /// <response code="201">Питомец успешно создан.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(PetOutputModel), 201)]
    [ProducesResponseType(400)]
    [HttpPost]
    public async Task<IActionResult> CreateUserPet([FromBody] PetInputModel model)
    {   
        long userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new CreatePetCommand(userId, model));
        return result.ToActionResult();
    }

    /// <summary>
    /// Получить питомца по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор питомца</param>
    /// <returns> Модель найденного питомца </returns>
    /// <response code="200"> Питомец найден.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(typeof(PetOutputModel), 200)]
    [ProducesResponseType(400)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(long id)
    {
        var result = await _mediator.Send(new GetPetByIdQuery(id));
        return result.ToActionResult();
    }

    /// <summary>
    /// Изменить питомца по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор питомца</param>
    /// <param name="model"> Входная модель питомца</param>
    /// <response code="204">Питомец успешно отредактирован.</response>
    /// <response code="400">Некорректный запрос.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [HttpPut("{id}")]
    public async Task<IActionResult> EditPetById(long id, [FromBody] PetInputModel model)
    {
        var result =  await _mediator.Send(new UpdatePetCommand(id, model));
        return result.ToActionResult();
    }

    /// <summary>
    /// Получить фотографии питомца
    /// </summary>
    /// <param name="id"> Уникальный индетификатор питомца</param>
    /// <returns> Фотографию </returns>
    /// <response code="200"> Запрос успешный. Возвращает фотграфию</response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("{id}/image")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetPetImage(long id)
    {
        var result = await _mediator.Send(new GetPetImageByIdQuery(id));

        if (result.IsSuccess)
        {
            return File(result.GetValue(), "image/jpeg");
        }

        return result.ToActionResult();
    }
    /// <summary>
    /// Добавить фото питомца
    /// </summary>
    /// <param name="id"> Уникальный индетификатор питомца</param>
    /// <param name="picture">  Новая фотография питомца</param>
    /// <response code="201">Фотография питомца успешно добавлена.</response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpPut("{id}/image")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdatePetImage(IFormFile picture, long id)
    {

        if (picture.ContentType is not "image/jpeg" && picture.ContentType is not "image/png" && picture.ContentType is not "image/jpg")
        {
            return StatusCode(415, "Unsupported media type.");
        }

        var result = await _mediator.Send(new UpdatePetImageCommand(id, picture));

        if (result.IsSuccess)
        {
            return File(result.GetValue(), "image/jpeg");
        }

        return result.ToActionResult();
    }

    /// <summary>
    /// Удалить питомца по ID
    /// </summary>
    /// <param name="id">Уникальный индетификатор питомца</param>
    /// <response code="204">Питомец успешно удален.</response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeletePetById(long id)
    {
        var result = await _mediator.Send(new DeletePetCommand(id));
        return result.ToActionResult();
    }
}
