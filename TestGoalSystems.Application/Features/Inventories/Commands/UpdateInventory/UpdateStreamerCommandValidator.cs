using FluentValidation;

namespace TestGoalSystems.Application.Features.Inventories.Commands.UpdateInventory
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{Name} cannot be blanck.")
               .NotNull()
               .MaximumLength(50).WithMessage("{Name} cannot exceed 50 characters.");
        }
    }
}
