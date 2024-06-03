using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Queries.Services.GetServiceByIdQuery;

public record GetServiceByIdQuery(long ServiceId) : IRequest<Result<ServiceOutputModel>>;
