using FluentValidation;

namespace Application.Features.PositionHistories.Commands.DeletePositionHistoryCommand
{
    public class DeletePositionHistoryCommandValidator : AbstractValidator<DeletePositionHistoryCommand>
    {
        public DeletePositionHistoryCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a cero");
        }
    }
}
