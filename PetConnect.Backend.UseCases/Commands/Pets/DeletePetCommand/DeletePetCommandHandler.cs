using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Pets.DeletePetCommand;

public class DeletePetCommandHandler(IPetRepository petRepository) : IRequestHandler<DeletePetCommand, Result<Unit>>
{
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));

    public async Task<Result<Unit>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetById(request.PetId);

        if (pet is null)
        {
            return Result<Unit>.Invalid($"Pet with {request.PetId} is doesn't exist!");
        }

        await _petRepository.Delete(pet);

        return Result<Unit>.Empty();
    }
}
