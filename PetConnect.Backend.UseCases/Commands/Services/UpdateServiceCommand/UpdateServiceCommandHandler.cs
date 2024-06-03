using AutoMapper;
using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Commands.Services.UpdateServiceCommand;

public class UpdateServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper) : IRequestHandler<UpdateServiceCommand, Result<Unit>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Result<Unit>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var existingService = await _serviceRepository.GetById(request.ServiceId);
        if (existingService == null)
        {
            return Result<Unit>.Invalid($"Service with id {request.ServiceId} doesn't exist!.");
        }

        _mapper.Map(request.Model, existingService);

        await _serviceRepository.Update(existingService);

        return Result<Unit>.Success(Unit.Value);
    }
}