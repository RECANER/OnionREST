using FluentValidation;

namespace Application.Features.Employees.Commands.CreateEmployeeCommand
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.CurrentPosition)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio");

            RuleFor(p => p.Salary)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser un valor positivo");
        }
    }
}
