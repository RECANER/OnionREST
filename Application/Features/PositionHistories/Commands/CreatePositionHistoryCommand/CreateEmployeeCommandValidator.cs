using FluentValidation;

namespace Application.Features.PositionHistories.Commands.CreatePositionHistoryCommand
{
    public class CreatePositionHistoryCommandValidator : AbstractValidator<CreatePositionHistoryCommand>
    {
        public CreatePositionHistoryCommandValidator()
        {
            RuleFor(p => p.EmployeeId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a cero");

            RuleFor(p => p.Position)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .LessThanOrEqualTo(p => p.EndDate.GetValueOrDefault(DateTime.Now)).WithMessage("{PropertyName} debe ser antes de la fecha de finalización");

            RuleFor(p => p.EndDate)
                .GreaterThanOrEqualTo(p => p.StartDate).When(p => p.EndDate.HasValue).WithMessage("{PropertyName} debe ser después de la fecha de inicio");
        }
    }
}
