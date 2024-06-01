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
using PetConnect.Backend.UseCases.Queries.UserProfiles.GetUserProfileByIdQuery;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для взаимодействия с текующим пользователем
/// </summary>
[Authorize(Roles = "PetSitter, PetOwner, Admin")]
[Route("api/user")]
[ApiController]
public class UserController(IMediator mediator, UserAccessor userAccessor) : ControllerBase
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
    [HttpGet("profile")]
    [ProducesResponseType(typeof(IAsyncEnumerable<UserProfile>),200)]
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
    /// <response code="200"> Успешно без контента </response>
    /// <response code="400"> Некорректный запрос </response>
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
    /// Изменить картинку профиля текущего пользователя
    /// </summary>
    /// <response code="204"> Успешно без контента </response>
    /// <response code="400"> Некорректный запрос </response>
    [HttpPut("profile/picture")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateProfilePicture()
    {
        long userId = _userAccessor.GetUserId();

        throw new NotImplementedException();
    }

    /// <summary>
    /// Изменить почту текущего пользователя
    /// </summary>
    /// <response code="204"> Успешно без контента </response>
    /// <response code="400"> Некорректный запрос </response>
    /// <param name="email"> Измененная почта</param>
    [HttpPut("/email")]
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
        /// <response code="204"> Успешно без контента </response>
        /// <response code="400"> Некорректный запрос </response>
        /// <param name="password"> Измененный пароль</param>
        [HttpPut("/password")]
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
    /// <response code="204"> Успешно без контента </response>
    /// <response code="400"> Некорректный запрос </response>
    [HttpDelete("")]
    public async Task<IActionResult> DeleteUser()
    {
        long userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new DeleteUserCommand(userId));
        return result.ToActionResult();
    }
}
 