using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PetConnect.Backend.Infrastructure;
using PetConnect.Backend.UseCases.Commands.Bookings;
using PetConnect.Backend.UseCases.Commands.Bookings.AddBookingCommand;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.Service.Controllers;

/// <summary>
/// Контроллер для взаимодействия с бронированием 
/// </summary>
[Route("api/bookings")]
[ApiController]
public class BookingsController(IMediator mediator, UserAccessor userAccessor)
{
    /// <summary>
    /// Посредник
    /// </summary>
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// Сервис для доступа к данным пользователя
    /// </summary>
    private readonly UserAccessor _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));

    [Authorize(Roles = "PetSitter, PetOwner")]
    [HttpGet]
    public Task<IActionResult> GetAllBookings()
    {
        var userId = _userAccessor.GetUserId();
        throw new NotImplementedException();
    }

    [Authorize(Roles = "PetOwner")]
    [HttpPost]
    public async Task<IActionResult> CreateNewBooking(BookingInputModel model)
    {
        var userId = _userAccessor.GetUserId();

        var result = await _mediator.Send(new AddBookingCommand(userId, model));
        return result.ToActionResult();
    }

    [Authorize(Roles = "PetSitter, PetOwner")]
    [HttpGet("{id}")]
    public Task<IActionResult> GetBookingById(long id)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles = "PetSitter")]
    [HttpPost("{id}/change-status")]
    public Task<IActionResult> ChangeBookingStatus(long id)
    {
        var userId = _userAccessor.GetUserId();

        throw new NotImplementedException();
    }

    [Authorize(Roles = "PetOwner")]
    [HttpPost("{id}/payment")]
    public Task<IActionResult> AddBookingPayment(long id)
    {
        var userId = _userAccessor.GetUserId();

        throw new NotImplementedException();
    }
}
