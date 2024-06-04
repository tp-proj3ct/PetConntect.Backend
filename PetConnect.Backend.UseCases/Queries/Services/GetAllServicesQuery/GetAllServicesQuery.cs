using MediatR;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Queries.Services.GetAllServicesQuery;

public class GetAllServicesQuery : IStreamRequest<Service>;