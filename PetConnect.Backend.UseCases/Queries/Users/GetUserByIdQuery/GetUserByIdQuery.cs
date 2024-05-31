using MediatR;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Queries.Users.GetUserByIdQuery;

public class GetUserByIdQuery(long id) : IRequest<Result<User>>
{
    public long Id { get; set; } = id;
}