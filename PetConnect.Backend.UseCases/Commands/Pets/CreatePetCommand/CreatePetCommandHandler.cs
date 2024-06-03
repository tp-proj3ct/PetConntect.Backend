using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Pets.CreatePetCommand;

public class CreatePetCommandHandler(IPetRepository petRepository, IUserRepository userRepository, IMapper mapper) : IRequestHandler<CreatePetCommand, Result<PetOutputModel>>
{
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Result<PetOutputModel>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId);

        if (user is null)
        {
            return Result<PetOutputModel>.Invalid($"User with id {request.UserId} doesn't exist!");
        }

        var pet = _mapper.Map<Pet>(request.Model);
        pet.PetOwnerId = request.UserId;

        await _petRepository.Add(pet);

        return Result<PetOutputModel>.SuccessfullyCreated(_mapper.Map<PetOutputModel>(pet));
    }
}
