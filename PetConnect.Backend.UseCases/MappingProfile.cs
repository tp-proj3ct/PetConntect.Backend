using AutoMapper;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.UseCases.Commands.Bookings;
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

        CreateMap<BookingInputModel, Booking>()
            .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.ServiceId))
            .ForMember(dest => dest.Pets, opt => opt.Ignore()) 
            .ForMember(dest => dest.StartedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.EndDate, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => Status.PendingConfirmation)) 
            .ForMember(dest => dest.ServiceAddress, opt => opt.MapFrom(src => src.ServiceAddress))
            .ForMember(dest => dest.AdditionalRequirements, opt => opt.MapFrom(src => src.AdditionalRequirements))
            .ForMember(dest => dest.CustomerComment, opt => opt.MapFrom(src => src.CustomerComment))
            .ForMember(dest => dest.Payment, opt => opt.Ignore());
        CreateMap<Booking, BookingOutputModel>();
        
    }
}
