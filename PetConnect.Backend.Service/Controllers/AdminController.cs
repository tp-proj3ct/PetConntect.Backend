using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Queries.Users.GetAllUsersQuery;

namespace PetConnect.Backend.Service.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/admin")]
[ApiController]
public class AdminController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// Получить всех юзеров. 
    /// </summary>
    /// <returns> Массив из юзеров </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IAsyncEnumerable<User>), 200)]
    public IAsyncEnumerable<User> GetAll()
    {
        return _mediator.CreateStream(new GetAllUsersQuery());
    }
}
