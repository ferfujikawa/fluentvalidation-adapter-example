using FluentValidation;
using fluentvalidation_adapter_example.Domain.Commands;

namespace fluentvalidation_adapter_example.Infra.Validators
{
    public class AddPersonCommandValidator : AbstractCommandValidator<AddPersonCommand>
    {
        protected override void LoadRules()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres");
            RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage("Este sistema permite apenas o cadastro de pessoas com no mínimo 18 anos");
        }
    }
}
