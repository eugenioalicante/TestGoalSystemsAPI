using FluentValidation;

namespace TestGoalSystems.Application.Features.Inventories.Commands.CreateInventory
{
    public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
    {
        public CreateInventoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} cannot be blanck.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} cannot exceed 50 characters.");           
        }
    }
}
