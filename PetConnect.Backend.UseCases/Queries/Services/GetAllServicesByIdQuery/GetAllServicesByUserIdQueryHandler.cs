using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Services.GetAllServicesQuery;

public class GetAllServicesByUserIdQueryHandler(IServiceRepository serviceRepository, IUserRepository userRepository, IMapper mapper) : IStreamRequestHandler<GetAllServicesByUserIdQuery, ServiceOutputModel>
{
    private readonly IServiceRepository _serivceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async IAsyncEnumerable<ServiceOutputModel> Handle(GetAllServicesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId);

        if (user is not null)
        {
            await foreach (var service in _serivceRepository.GetAllByUserId(request.UserId))
            {
                yield return _mapper.Map<ServiceOutputModel>(service);
            }
        }
    }
}