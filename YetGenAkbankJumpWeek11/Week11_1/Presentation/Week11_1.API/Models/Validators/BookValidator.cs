using FluentValidation;
using Week11_1.Domain.Entities;

namespace Week11_1.API.Models.Validators
{
	public class BookValidator : AbstractValidator<Book>
	{
        public BookValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title cannot be empty")
                .NotNull().WithMessage("Title cannot be null");

            RuleFor(x => x.Author).NotNull().WithMessage("Author cannot be null")
                .MaximumLength(65).WithMessage("Author name cannot be longer than 65 characters");

            RuleFor(x => x.PurchasePrice).NotNull().WithMessage("Purchase price cannot be null")
                .GreaterThan(0.5m).WithMessage("Purchase price cannot be less than 0.5$");
                

        }
    }
}
