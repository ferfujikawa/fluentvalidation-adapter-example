namespace fluentvalidation_adapter_example.Domain.Validators
{
    public interface ICommandValidator<T>
    {
        public bool IsValid { get; }
        public IEnumerable<string> Errors { get; }

        public abstract Task ValidateExecAsync(T objectToValidate);
    }
}
