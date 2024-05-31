using MediatR;
using Microsoft.AspNetCore.Authorization;
using PetConnect.Packages.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;
using PetConnect.Backend.UseCases.Commands.Auth.LoginCommand;

namespace PetConnect.Backend.Service.Controllers;

[Route("api/auth")]
[AllowAnonymous]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationCommand request)
    {
        var result = await _mediator.Send(request);
        return result.ToActionResult();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        var result = await _mediator.Send(request);
        return result.ToActionResult();
    }
}
