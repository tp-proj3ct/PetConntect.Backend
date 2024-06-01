using MediatR;
using Microsoft.Extensions.Options;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core.Options;
using PetConnect.Backend.Core.Users;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;

namespace PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;

public class RegistrationCommandHandler(IUserRepository userRepository, 
                                        IUserProfileRepository userProfileRepository, 
                                        IOptions<PasswordOptions> passwordOptions) : IRequestHandler<RegistrationCommand, Result<Unit>>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IUserProfileRepository _userProfileRepository =  userProfileRepository ?? throw new ArgumentException(nameof(userProfileRepository));
    private readonly PasswordOptions _passwordOptions = passwordOptions?.Value ?? throw new ArgumentNullException(nameof(passwordOptions));

    public async Task<Result<Unit>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var existingUserWithEmail = await _userRepository.GetByEmail(request.Email);
        if (existingUserWithEmail is not null)
        {
            return Result<Unit>.Conflict("User with this email already exists!");
        }

        var existingUserWithLogin = await _userRepository.GetByLogin(request.Login);
        if (existingUserWithLogin is not null)
        {
            return Result<Unit>.Conflict("User with this login already exists!");
        }

        if (!Enum.TryParse<Role>(request.Role, true, out Role parsedRole) || !Enum.IsDefined(typeof(Role), parsedRole))
        {
            return Result<Unit>.Invalid("Invalid user role!");
        }

        User user;
        switch(parsedRole)
        {
            case Role.PetSitter:
                user = new PetSitter { Login = request.Login, Email = request.Email, Role = Role.PetSitter };
                break;
            case Role.PetOwner:
                user = new PetOwner{ Login = request.Login, Email = request.Email, Role = Role.PetOwner };
                break;
            case Role.Admin:
                user = new Admin { Login = request.Login, Email = request.Email, Role = Role.Admin };
                break;
            default:
                return Result<Unit>.Invalid("Invalid user role!");
        }


        user.SetPassword(request.Password, _passwordOptions);
        
        await _userRepository.Add(user);
        await _userProfileRepository.Add(new UserProfile { UserId = user.Id });

        return Result<Unit>.SuccessfullyCreated(Unit.Value);
    }
}
