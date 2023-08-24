using FluentValidation;
using FluentValidation.Results;
using fluentvalidation_adapter_example.Domain.Validators;

namespace fluentvalidation_adapter_example.Infra.Validators
{
    public abstract class AbstractCommandValidator<T> : AbstractValidator<T>, ICommandValidator<T>
    {
        protected ValidationResult _result { get; set; } = new ValidationResult();
        public bool IsValid => _result.IsValid;
        public IEnumerable<string> Errors => _result.Errors.Select(x => x.ErrorMessage);

        protected AbstractCommandValidator()
        {
            LoadRules();
        }

        public async Task ValidateExecAsync(T command) => _result = await ValidateAsync(command);

        protected abstract void LoadRules();
    }
}
