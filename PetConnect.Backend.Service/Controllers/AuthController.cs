using MediatR;
using Microsoft.AspNetCore.Authorization;
using PetConnect.Packages.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;
using PetConnect.Backend.UseCases.Commands.Auth.LoginCommand;
using System;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для авторизации
/// </summary>
[Route("api/auth")]
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
    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationCommand request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(request);
        return result.ToActionResult();
    }
    /// <summary>
    /// Авторизация
    /// </summary>
    /// <returns> Токен </returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(request);
        return result.ToActionResult();
    }
}
