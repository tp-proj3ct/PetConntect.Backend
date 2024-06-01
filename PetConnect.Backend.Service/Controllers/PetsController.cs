using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Infrastructure;

namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для работы с сиделками
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

    [HttpGet("")]
    public async Task<IActionResult> GetAllUserPets()
    {
        long userId = _userAccessor.GetUserId();
        return Ok(userId);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateUserPet()
    {
        long userId = _userAccessor.GetUserId();
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(long id)
    {
        
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditPetById(long id)
    {
        
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePetById(long id)
    {
        throw new NotImplementedException();
    }
}
