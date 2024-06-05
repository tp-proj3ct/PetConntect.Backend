using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Bookings.GetBookingsByPetOwnerIdQuery;

public class GetBookingsByPetOwnerIdQueryHandler : IStreamRequestHandler<GetBookingsByPetOwnerIdQuery, BookingForPetOwnerOutputModel>
{
    public IAsyncEnumerable<BookingForPetOwnerOutputModel> Handle (GetBookingsByPetOwnerIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
