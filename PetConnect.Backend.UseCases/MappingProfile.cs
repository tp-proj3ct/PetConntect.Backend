using AutoMapper;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Commands.Pets;


namespace PetConnect.Backend.UseCases;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PetInputModel, Pet>();
        CreateMap<Pet, PetOutputModel>();
    }
}
