using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Pets.UpdatePetImageCommand;

public class UpdatePetImageCommandHandler(IPetRepository petRepository) : IRequestHandler<UpdatePetImageCommand, Result<byte[]>>
{
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));

    public async Task<Result<byte[]>> Handle(UpdatePetImageCommand request, CancellationToken cancellationToken)
    {
        if (request.Picture == null || request.Picture.Length == 0)
        {
            return Result<byte[]>.Invalid("Picture is required.");
        }

        byte[] pictureBytes;
        using (var memoryStream = new MemoryStream())
        {
            await request.Picture.CopyToAsync(memoryStream, cancellationToken);
            pictureBytes = memoryStream.ToArray();
        }

        var pet = await _petRepository.GetById(request.PetId);

        if (pet is null)
        {
            return Result<byte[]>.Invalid($"Pet with Id {request.PetId} not found");
        }

        pet.Picture = pictureBytes;
        await _petRepository.Update(pet);

        return Result<byte[]>.SuccessfullyCreated(pictureBytes);
    }
}
