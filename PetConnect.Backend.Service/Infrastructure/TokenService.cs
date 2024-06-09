﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetConnect.Backend.Core;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core.Options;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.Infrastructure;

/// <summary>
/// Реализация <see cref="ITokenService"/>.
/// </summary>
public class TokenService(IOptions<JwtOptions> jwtOptions) : ITokenService
{
    /// <summary>
    /// Параметры JWT токена.
    /// </summary>
    private readonly JwtOptions _jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));

    /// <inheritdoc/>
    public Token GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOptions.ExpiryMinutes),
            signingCredentials: creds);

        return new Token(new JwtSecurityTokenHandler().WriteToken(token));
    }
}