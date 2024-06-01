using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Queries.Users.GetAllUsersQuery;

namespace PetConnect.Backend.Service.Controllers;

using Service = PetConnect.Backend.Core.Service;

[Authorize(Roles = "Admin")]
[Route("api/admin")]
[ApiController]
public class AdminController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    #region Users

    /// <summary>
    /// Получить всех юзеров. 
    /// </summary>
    /// <returns> Массив из юзеров </returns>
    [Route("users")]
    [HttpGet]
    [ProducesResponseType(typeof(IAsyncEnumerable<User>), 200)]
    public  IAsyncEnumerable<User> GetAllUsers()
    {
        return _mediator.CreateStream(new GetAllUsersQuery());
    }

    [HttpGet("users/{id}")]
    public Task<IActionResult> GetUserById()
    {
        throw new NotImplementedException();
    }

    [HttpPost("users/{id}/activate")]
    public Task<IActionResult> ActivateUser()
    {
        throw new NotImplementedException();
    }

    [HttpPost("users/{id}/deactivate")]
    public Task<IActionResult> DeactivateUser()
    {
        throw new NotImplementedException();
    }

    [HttpPost("users/{id}/block")]
    public Task<IActionResult> BlockUser()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Bookings


    /// <summary>
    /// Получить все бронирования. 
    /// </summary>
    /// <returns> Массив из бронирований </returns>
    [HttpGet("booking")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Booking>), 200)]
    public IAsyncEnumerable<Booking> GetAllBookings()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Pets

    /// <summary>
    /// Получить всех питомцев. 
    /// </summary>
    /// <returns> Массив из питомцев </returns>
    [HttpGet("pets")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Pet>), 200)]
    public IAsyncEnumerable<Pet> GetAllPets()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Payments

    /// <summary>
    /// Получить все платежи. 
    /// </summary>
    /// <returns> Массив из платежей </returns>
    [HttpGet("payments")]
    [ProducesResponseType(typeof(IAsyncEnumerable<User>), 200)]
    public IAsyncEnumerable<User> GetAllPayments() // TODO
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Services
    /// <summary>
    /// Получить все услуги
    /// </summary>
    /// <returns> Массив из услуг </returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("services")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Service>), 200)]
    public IAsyncEnumerable<Service> GetAllServices()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Reviews

    [HttpGet("reviews")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Review>), 200)]
    public IAsyncEnumerable<Review> GetAllReviews()
    {
        throw new NotImplementedException();
    }

    #endregion
}