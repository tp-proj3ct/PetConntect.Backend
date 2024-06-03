namespace PetConnect.Backend.UseCases.Commands.Pets;

using FluentValidation;
using PetConnect.Backend.Core.Abstractions;

public class PetInputModelValidator : AbstractValidator<PetInputModel>
{
    public PetInputModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters.");

        RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0.");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0.");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .Must(BeAValidGender).WithMessage("Invalid gender specified.");

        RuleFor(x => x.Behavior)
            .NotEmpty().WithMessage("Behavior is required.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required.");

        RuleFor(x => x.Breed)
            .NotEmpty().WithMessage("Breed is required.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must be less than 500 characters.");

        RuleFor(x => x.MedicalInfo)
            .MaximumLength(500).WithMessage("MedicalInfo must be less than 500 characters.");
    }

    private bool BeAValidGender(string gender)
    {
        return Enum.TryParse<Gender>(gender, false, out _) && Enum.IsDefined(typeof(Gender), gender);
    }
}
