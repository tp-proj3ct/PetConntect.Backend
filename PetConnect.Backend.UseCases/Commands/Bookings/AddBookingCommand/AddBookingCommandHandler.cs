using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Bookings.AddBookingCommand;

public class AddBookingCommandHandler(IBookingRepository bookingRepository,
                                      IPetRepository petRepository,
                                      IUserRepository userRepository,
                                      IServiceRepository serviceRepository,
                                      IMapper mapper) : IRequestHandler<AddBookingCommand,Result<BookingOutputModel>>
{
    private readonly IBookingRepository _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IServiceRepository _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Result<BookingOutputModel>> Handle(AddBookingCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetById(request.CustomerId);
        if (user is null)
        {
            return Result<BookingOutputModel>.Invalid($"User with Id {request.CustomerId} is doesn't exist!");
        }

        var service = await _serviceRepository.GetById(request.Model.ServiceId);
        if (service is null)
        {
            return Result<BookingOutputModel>.Invalid($"Service with Id {request.Model.ServiceId} is doesn't exist!");
        }

        var booking = _mapper.Map<Booking>(request.Model);
        booking.CustomerId = request.CustomerId;

        if (request.Model.PetIds != null)
        {
            foreach (var petId in request.Model.PetIds)
            {
                var pet = await _petRepository.GetById(petId);
                if (pet is null)
                {
                    return Result<BookingOutputModel>.Invalid($"Pet with Id {petId} is doesn't exist!");
                }
                //booking.Pets.Add(pet);
                // TODO Добавить добавлениме петов в промежуточную таблицу
            }
        }

        await _bookingRepository.Add(booking);
        return Result<BookingOutputModel>.SuccessfullyCreated(_mapper.Map<BookingOutputModel>(booking));
    }

}
