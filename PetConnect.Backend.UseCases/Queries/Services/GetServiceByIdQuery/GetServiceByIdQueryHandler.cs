using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Queries.Services.GetServiceByIdQuery;

public class GetServiceByIdQueryHandler(IServiceRepository serviceRepository, IMapper mapper) : IRequestHandler<GetServiceByIdQuery, Result<ServiceOutputModel>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Result<ServiceOutputModel>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetById(request.ServiceId);

        if (service == null)
        {
            return Result<ServiceOutputModel>.Invalid($"Pet with id {request.ServiceId} doesn't exist!");
        }

        return Result<ServiceOutputModel>.Success(_mapper.Map<ServiceOutputModel>(service));
    }
}
