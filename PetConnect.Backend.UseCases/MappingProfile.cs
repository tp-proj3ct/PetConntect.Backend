using AutoMapper;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Users;
using PetConnect.Backend.UseCases.Commands.Pets;
using PetConnect.Backend.UseCases.Commands.Reviews;
using PetConnect.Backend.UseCases.Commands.Services;


namespace PetConnect.Backend.UseCases;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PetInputModel, Pet>();
        CreateMap<Pet, PetOutputModel>();

        CreateMap<ServiceInputModel, Service>();
        CreateMap<Service, ServiceOutputModel>();

        CreateMap<ReviewInputModel, Review>();
        CreateMap<Review, ReviewOutputModel>();
    }
}
