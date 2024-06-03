using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Pets.GetAllPetsByUserIdQuery;

public class GetAllPetsByUserIdQueryHandler(IPetRepository petRepository, IMapper mapper, IUserRepository userRepository) : IStreamRequestHandler<GetAllPetsByUserIdQuery, PetOutputModel>
{
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
 
    public async IAsyncEnumerable<PetOutputModel> Handle(GetAllPetsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId);

        if (user is not null)
        {
            await foreach (var pet in _petRepository.GetAllByUserId(request.UserId))
            {
                yield return _mapper.Map<PetOutputModel>(pet);
            }
        }
    }
}
