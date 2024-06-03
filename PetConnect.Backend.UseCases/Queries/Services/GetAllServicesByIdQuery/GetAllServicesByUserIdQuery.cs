using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Backend.Core;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Services.GetAllServicesQuery;

public record GetAllServicesByUserIdQuery(long UserId) : IStreamRequest<ServiceOutputModel>;