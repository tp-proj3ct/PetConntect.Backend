
using MediatR;
using PetConnect.Packages.UseCases;
using System.ComponentModel.DataAnnotations;

namespace PetConnect.Backend.UseCases.Commands.User.ChangeEmailCommand;

public class ChangeEmailCommand(long userId, string email) : IRequest<Result<Unit>>
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = email;

    public long UserId { get; set; } = userId;
}
