using FluentValidation;

namespace Application.Features.Employees.Commands.UpdateEmployeeCommand
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.CurrentPosition)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser un valor positivo");

            RuleFor(p => p.Salary)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser un valor positivo");
        }
    }
}
