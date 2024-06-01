using MediatR;
using PetConnect.Packages.UseCases;
using System.ComponentModel.DataAnnotations;

namespace PetConnect.Backend.UseCases.Commands.User.ChangePasswordCommand
{
    public  class ChangePasswordCommand (long userId, string email) : IRequest<Result<Unit>>
    {
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        public long UserId { get; set; }
    }
    
}
