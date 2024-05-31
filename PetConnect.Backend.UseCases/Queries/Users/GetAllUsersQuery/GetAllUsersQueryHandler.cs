using MediatR;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core.Options;
using PetConnect.Backend.Core.Users;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.UseCases.Queries.Users.GetAllUsersQuery;

public class GetAllUsersQueryHandler(IUserRepository userRepository) : IStreamRequestHandler<GetAllUsersQuery, User>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public IAsyncEnumerable<User> Handle(GetAllUsersQuery _, CancellationToken cancellationToken)
    {
        return _userRepository.GetAll();
    }
}