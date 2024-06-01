using MediatR;
using Microsoft.AspNetCore.Authorization;
using PetConnect.Packages.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;
using PetConnect.Backend.UseCases.Commands.Auth.LoginCommand;
using System;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для авторизации
/// </summary>
[Route("api/auth")]
[ApiController]
[AllowAnonymous]
public class AuthController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Медиатор
    /// </summary>
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// Регистрация
    /// </summary>
    /// <response code="200"> Успешно </response>
    /// <response code="400"> Некоретный запрос </response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationCommand request)
    {
        var result = await _mediator.Send(request);
        return result.ToActionResult();
    }
    /// <summary>
    /// Авторизация
    /// </summary>
    /// <response code="200"> Успешно </response>
    /// <returns> Токен </returns>
    /// <response code="400"> Некоретный запрос </response>
    [ProducesResponseType(typeof(Token), 200)]
    [ProducesResponseType(400)]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        var result = await _mediator.Send(request);
        return result.ToActionResult();
    }
}
