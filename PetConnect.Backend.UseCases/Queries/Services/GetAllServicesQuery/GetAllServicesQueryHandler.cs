using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.UseCases.Queries.Services.GetAllServicesQuery;

public class GetAllServicesQueryHandler(IServiceRepository serviceRepository) : IStreamRequestHandler<GetAllServicesQuery, Service>
{
    private readonly IServiceRepository _serivceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));

    public IAsyncEnumerable<Service> Handle(GetAllServicesQuery _, CancellationToken cancellationToken)
    {
        return _serivceRepository.GetAll();
    }
}