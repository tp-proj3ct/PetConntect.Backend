using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Core;
using PetConnect.Backend.Infrastructure;
using PetConnect.Backend.UseCases.Commands.User.ChangeEmailCommand;
using PetConnect.Backend.UseCases.Commands.User.ChangePasswordCommand;
using PetConnect.Backend.UseCases.Commands.User.DeleteUserCommand;
using PetConnect.Backend.UseCases.Commands.UserProfiles;
using PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfileCommand;
using PetConnect.Backend.UseCases.Commands.UserProfiles.UpdateUserProfilePictureCommand;
using PetConnect.Backend.UseCases.Queries.UserProfiles.GetUserProfileByIdQuery;
using PetConnect.Backend.UseCases.Queries.UserProfiles.GetUserProfilePictureByIdQuery;
using PetConnect.Packages.UseCases;
using System.Net.Mime;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для взаимодействия с текующим пользователем
/// </summary>
[Authorize(Roles = "PetSitter, PetOwner, Admin")]
[Route("api/user")]
[ApiController]
public class UsersController(IMediator mediator, UserAccessor userAccessor) : ControllerBase
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
    /// Получить профиль текущего пользователя
    /// </summary>
    /// <returns></returns>
    /// <response code="200"> Успешно. Возвращает найденный профиль. </response>
    /// <response code="400"> Некорректный запрос. </response>
    [HttpGet("profile")]
    [ProducesResponseType(typeof(UserProfile),200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetProfile()
    {
        long userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new GetUserProfileByUserIdQuery(userId));
        return result.ToActionResult();
    }

    /// <summary>
    /// Изменить профиль текущего пользователя
    /// </summary>
    /// <response code="204"> Успешно без контента. </response>
    /// <response code="400"> Некорректный запрос. </response>
    [HttpPut("profile")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateProfile(UserProfileInputModel request)
    {
        long userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new UpdateUserProfileCommand(userId, request));
        return result.ToActionResult();
    }

    /// <summary>
    /// Получить картинку профиля текущего пользователя
    /// </summary>
    /// <response code="200"> Успешно. Возвращает картинку профиля. </response>
    /// <response code="404"> Пользователь или картинка не найдены. </response>
    [HttpGet("profile/picture")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetProfilePicture()
    {
        long userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new GetUserProfilePictureByIdQuery(userId));

        if (result.IsSuccess)
        {
            return File(result.GetValue(), "image/jpeg");
        }

        return result.ToActionResult();
    }

    /// <summary>
    /// Изменить картинку профиля текущего пользователя
    /// </summary>
    /// <param name="picture"> Новая картинка профиля</param>
    /// <response code="201"> Успешно. Возвращает картинку. </response>
    /// <response code="400"> Некорректный запрос. </response>
    /// <response code="415"> Неподдерживаемый тип медиа. </response>
    [HttpPost("profile/picture")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(415)]
    public async Task<IActionResult> UpdateProfilePicture(IFormFile picture)
    {
        long userId = _userAccessor.GetUserId();

        if (picture.ContentType is not "image/jpeg" && picture.ContentType is not "image/png" && picture.ContentType is not "image/jpg")
        {
            return StatusCode(415, "Unsupported media type.");
        }

        var result = await _mediator.Send(new UpdateUserProfilePictureCommand(userId, picture));

        if (result.IsSuccess)
        {
            return File(result.GetValue(), "image/jpeg");
        }

        return result.ToActionResult();
    }


    /// <summary>
    /// Изменить почту текущего пользователя
    /// </summary>
    /// <response code="204"> Успешно без контента. </response>
    /// <response code="400"> Некорректный запрос. </response>
    /// <param name="email"> Измененная почта</param>
    [HttpPost("/change-email")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ChangeEmail(string email )
        {
            long userId = _userAccessor.GetUserId();

            var result = await _mediator.Send(new ChangeEmailCommand(userId, email));
            return result.ToActionResult();
        }

    /// <summary>
    /// Изменить пароль текущего пользователя
    /// </summary>
    /// <response code="204"> Успешно без контента.</response>
    /// <response code="400"> Некорректный запрос. </response>
    /// <param name="password"> Измененный пароль</param>
    [HttpPost("/change-password")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ChangePassword(string password)
        {
            long userId = _userAccessor.GetUserId();

            var result = await _mediator.Send(new ChangePasswordCommand(userId, password));
            return result.ToActionResult();
        }

    /// <summary>
    /// Удалить текущего пользователя
    /// </summary>
    /// <response code="204"> Успешно без контента. </response>
    /// <response code="400"> Некорректный запрос. </response>
    [HttpDelete("")]
    public async Task<IActionResult> DeleteUser()
    {
        long userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new DeleteUserCommand(userId));
        return result.ToActionResult();
    }
}
 