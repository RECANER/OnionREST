using FluentValidation;

namespace Application.Features.Employees.Commands.DeleteEmployeeCommand
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a cero");
        }
    }
}
