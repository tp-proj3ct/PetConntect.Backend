using FluentValidation;


namespace PetConnect.Backend.UseCases.Commands.Reviews;

public class ReviewInputModelValidator : AbstractValidator<ReviewInputModel>
{
    public ReviewInputModelValidator()
    {
        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment is required.")
            .Length(10, 500).WithMessage("Comment must be between 10 and 500 characters.");

        RuleFor(x => x.Rating)
            .GreaterThan(1).LessThan(10).WithMessage("Rating must be between 1 and 10 characters");
    }
}
