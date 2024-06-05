using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Bookings.GetBookingsByPetOwnerIdQuery;

public record GetBookingsByPetOwnerIdQuery(long PetOwnerId) : IStreamRequest<BookingForPetOwnerOutputModel>;

