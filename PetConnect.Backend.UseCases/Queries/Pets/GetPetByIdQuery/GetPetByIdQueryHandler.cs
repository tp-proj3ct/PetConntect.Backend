using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Pets.GetPetByIdQuery;

public class GetPetByIdQueryHandler(IPetRepository petRepository, IMapper mapper) : IRequestHandler<GetPetByIdQuery, Result<PetOutputModel>>
{
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Result<PetOutputModel>> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetById(request.PetId);

        if (pet == null)
        {
            return Result<PetOutputModel>.Invalid($"Pet with id {request.PetId} doesn't exist!");
        }

        var petOutputModel = _mapper.Map<PetOutputModel>(pet);
        return Result<PetOutputModel>.Success(petOutputModel);
    }
}