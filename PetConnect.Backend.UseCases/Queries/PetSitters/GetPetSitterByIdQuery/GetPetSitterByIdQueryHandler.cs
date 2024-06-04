using AutoMapper;
using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.PetSitters.GetPetSitterByIdQuery;

public class GetPetSitterByIdQueryHandler(IPetSitterRepository petSitterRepository,
                                          IUserProfileRepository userProfileRepository) : IRequestHandler<GetPetSitterByIdQuery, Result<PetSitterOutputModel>>
{
    private readonly IPetSitterRepository _petSitterRepository = petSitterRepository ?? throw new ArgumentNullException(nameof(petSitterRepository));
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));

    public async Task<Result<PetSitterOutputModel>> Handle(GetPetSitterByIdQuery request, CancellationToken cancellationToken)
    {
        var petSitter = await _petSitterRepository.GetById(request.PetSitterId);

        if (petSitter is null)
        {
            return Result<PetSitterOutputModel>.Invalid($"Pet sitter with id {request.PetSitterId} is doesn't exist!.");
        }

        var userProfile = await _userProfileRepository.GetByUserId(petSitter.Id);

        var outputModel = new PetSitterOutputModel
        {
            Id = request.PetSitterId,
            Name = userProfile.Name,
            Surname = userProfile.Surname,
            ProfilePic = userProfile.ProfilePic,
            Description = petSitter.Description,
            Rating = petSitter.Rating,
            ExperienceYears = petSitter.ExperienceYears
        };

        return Result<PetSitterOutputModel>.Success(outputModel);
    }
}