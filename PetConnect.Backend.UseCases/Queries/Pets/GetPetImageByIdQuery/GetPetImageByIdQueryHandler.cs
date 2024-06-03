using AutoMapper;
using MediatR;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Queries.Pets.GetPetImageByIdQuery;

public class GetPetImageByIdQueryHandler(IPetRepository petRepository) : IRequestHandler<GetPetImageByIdQuery, Result<byte[]>>
{
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));

    public async Task<Result<byte[]>> Handle(GetPetImageByIdQuery request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetById(request.PetId);

        if (pet is null)
        {
            return Result<byte[]>.Invalid($"Pet with id {request.PetId} doesn't exist!");
        }

        if (pet.Picture is null)
        {
            return Result<byte[]>.Invalid($"Picture of pet with id {request.PetId} doesn't exist!");
        }

        return Result<byte[]>.Success(pet.Picture);
    }
}