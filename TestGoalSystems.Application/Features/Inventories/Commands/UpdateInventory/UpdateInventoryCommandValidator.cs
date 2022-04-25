using FluentValidation;

namespace TestGoalSystems.Application.Features.Inventories.Commands.UpdateInventory
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {
        public UpdateInventoryCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{Name} cannot be blanck.")
               .NotNull()
               .MaximumLength(50).WithMessage("{Name} cannot exceed 50 characters.");
        }
    }
}
