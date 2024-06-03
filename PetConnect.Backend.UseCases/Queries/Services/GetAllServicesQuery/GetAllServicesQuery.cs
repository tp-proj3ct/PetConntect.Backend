using MediatR;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Queries.Services.GetAllServicesQuery;

public class GetAllSevicesQuery : IStreamRequest<Service>;