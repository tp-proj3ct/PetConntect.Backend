using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.PetSitters.GetAllPetSittersQuery;

public class GetAllPetSittersQueryHandler(IPetSitterRepository petSitterRepository, 
                                          IUserProfileRepository userProfileRepository, 
                                          IMapper mapper) : IRequestHandler<GetAllPetSittersQuery, Result<IEnumerable<PetSitterOutputModel>>>
{
    private readonly IPetSitterRepository _petSitterRepository = petSitterRepository ?? throw new ArgumentNullException(nameof(petSitterRepository));
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));

    public async Task<Result<IEnumerable<PetSitterOutputModel>>> Handle(GetAllPetSittersQuery request, CancellationToken cancellationToken)
    {
        var petSitterOutputModels = new List<PetSitterOutputModel>();

        foreach (var petSitter in _petSitterRepository.GetAll())
        {
            var userProfile = await _userProfileRepository.GetByUserId(petSitter.Id);

            var outputModel = new PetSitterOutputModel
            {
                Id = petSitter.Id,
                Name = userProfile.Name,
                Surname = userProfile.Surname,
                ProfilePic = userProfile.ProfilePic,
                Description = petSitter.Description,
                Rating = petSitter.Rating,
                ExperienceYears = petSitter.ExperienceYears
            };

            petSitterOutputModels.Add(outputModel);
        }

        return Result<IEnumerable<PetSitterOutputModel>>.Success(petSitterOutputModels);
    }
}