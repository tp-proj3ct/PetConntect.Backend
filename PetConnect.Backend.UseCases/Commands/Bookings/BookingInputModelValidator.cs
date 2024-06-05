using FluentValidation;
using System.Linq;

namespace PetConnect.Backend.UseCases.Commands.Bookings;

public class BookingInputModelValidator : AbstractValidator<BookingInputModel>
{
    public BookingInputModelValidator()
    {
        RuleFor(x => x.ServiceId)
            .NotEmpty().WithMessage("ServiceId is required.");

        RuleFor(x => x.PetIds)
            .Must(petIds => petIds != null && petIds.Count != 0).WithMessage("At least one PetId is required.")
            .When(x => x.PetIds != null);

        RuleFor(x => x.ServiceAddress)
            .NotEmpty().WithMessage("ServiceAddress is required.")
            .MaximumLength(256).WithMessage("ServiceAddress must not exceed 256 characters.");

        RuleFor(x => x.AdditionalRequirements)
            .MaximumLength(1024).WithMessage("AdditionalRequirements must not exceed 1024 characters.");

        RuleFor(x => x.CustomerComment)
            .MaximumLength(1024).WithMessage("CustomerComment must not exceed 1024 characters.");
    }
}
