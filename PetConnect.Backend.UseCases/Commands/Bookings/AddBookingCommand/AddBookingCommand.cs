using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Bookings.AddBookingCommand;

public record AddBookingCommand(long CustomerId, BookingInputModel Model) : IRequest<Result<BookingOutputModel>>;

