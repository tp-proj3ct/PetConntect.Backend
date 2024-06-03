using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Services.DeleteServiceCommand;

public class DeleteServiceCommandHandler(IServiceRepository serviceRepository) : IRequestHandler<DeleteServiceCommand, Result<Unit>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));

    public async Task<Result<Unit>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var existingService = await _serviceRepository.GetById(request.ServiceId);
        if (existingService == null)
        {
            return Result<Unit>.Invalid($"Service with id {request.ServiceId} doesn't exist!.");
        }

        await _serviceRepository.Delete(existingService);

        return Result<Unit>.Empty();
    }
}