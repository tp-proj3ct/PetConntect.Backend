using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Commands.Services.AddServiceCommand
{
    public class AddServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper) : IRequestHandler<AddServiceCommand, Result<ServiceOutputModel>>
    {
        private readonly IServiceRepository _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<Result<ServiceOutputModel>> Handle(AddServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(request.Model);

            service.PetSitterId = request.UserId;

            await _serviceRepository.Add(service);



            return Result<ServiceOutputModel>.SuccessfullyCreated(_mapper.Map<ServiceOutputModel>(service));
        }
    }
}