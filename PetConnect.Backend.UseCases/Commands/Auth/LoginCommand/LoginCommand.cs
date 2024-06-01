using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Packages.UseCases;


namespace PetConnect.Backend.UseCases.Commands.Auth.LoginCommand;

/// <summary>
/// Команда для авторизации пользователя
/// </summary>
/// <param name="Login"></param>
/// <param name="Password"></param>
/// <returns> Токен </returns>
public sealed record class LoginCommand(string Login, string Password) : IRequest<Result<Token>>;
