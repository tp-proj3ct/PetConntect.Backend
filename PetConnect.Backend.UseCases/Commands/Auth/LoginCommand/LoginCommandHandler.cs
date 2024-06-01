using MediatR;
using Microsoft.Extensions.Options;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Options;
using PetConnect.Backend.Core.Services;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Commands.Auth.LoginCommand;

public class LoginCommandHandler(IUserRepository userRepository,
                                 ITokenService tokenService,
                                 IOptions<PasswordOptions> passwordOptions) : IRequestHandler<LoginCommand, Result<Token>>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly ITokenService _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    private readonly string _salt = passwordOptions?.Value?.Salt ?? throw new ArgumentNullException(nameof(passwordOptions));

    public async Task<Result<Token>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Resolve(request.Login, CryptographyService.HashPassword(request.Password, _salt));

        if (user is null)
        {
            return Result<Token>.Invalid("Invalid password or login");
        }

        Token accessToken = _tokenService.GenerateToken(user);
        return Result<Token>.Success(accessToken);
    }
} 
