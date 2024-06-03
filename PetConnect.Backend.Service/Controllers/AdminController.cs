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

    /// <summary>
    /// Получить пользователя по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор пользователя</param>
    /// <returns> Юзера </returns>
    /// <response code="200"> Пользователь найден. </response>
    /// <response code="400"> Некорректный запрос </response> 
    [HttpGet("users/{id}")]
    [ProducesResponseType(typeof(User),200)]
    [ProducesResponseType(400)]
    public Task<IActionResult> GetUserById(long id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///  Активировать пользователя по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор пользователя </param>
    /// <response code="204"> Пользователь успешно активирован. </response>
    /// <response code="400"> Некорректный запрос </response>
    [HttpPost("users/{id}/activate")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public Task<IActionResult> ActivateUser(long id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Деактивирировать пользователя по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор пользователя </param>
    /// <response code="204"> Пользователь успешно деактивирован. </response>
    /// <response code="400"> Некорректный запрос </response>
    [HttpPost("users/{id}/deactivate")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public Task<IActionResult> DeactivateUser(long id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Заблокировать пользователя по ID
    /// </summary>
    /// <param name="id"> Уникальный индетификатор пользователя </param>
    /// <response code="204"> Пользователь успешно заблокирован. </response>
    /// <response code="400"> Некорректный запрос </response>
    [HttpPost("users/{id}/block")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public Task<IActionResult> BlockUser(long id)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Bookings


    /// <summary>
    /// Получить все бронирования. 
    /// </summary>
    /// <returns> Массив из бронирований </returns>
    /// <response code="200"></response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("booking")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Booking>), 200)]
    [ProducesResponseType(400)]
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
    /// <response code="200"></response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("pets")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Pet>), 200)]
    [ProducesResponseType(400)]
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
    /// Получить все отзывы
    /// </summary>
    /// <returns> Массив из отзывов </returns>
    /// <response code="200"></response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("services")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Service>), 200)]
    public IAsyncEnumerable<Service> GetAllServices()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Reviews

    /// <summary>
    /// Получить все отзывы
    /// </summary>
    /// <returns> Массив из отзывов </returns>
    /// <response code="200"></response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("reviews")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Review>), 200)]
    [ProducesResponseType(400)]
    public IAsyncEnumerable<Review> GetAllReviews()
    {
        throw new NotImplementedException();
    }

    #endregion
}