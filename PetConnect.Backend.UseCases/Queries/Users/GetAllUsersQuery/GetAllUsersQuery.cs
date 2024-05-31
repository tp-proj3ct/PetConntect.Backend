using MediatR;
using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.UseCases.Queries.Users.GetAllUsersQuery;

public class GetAllUsersQuery : IStreamRequest<User> { }