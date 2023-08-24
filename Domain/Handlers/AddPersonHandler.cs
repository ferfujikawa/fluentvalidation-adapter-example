using fluentvalidation_adapter_example.Domain.Commands;
using fluentvalidation_adapter_example.Domain.Validators;

namespace fluentvalidation_adapter_example.Domain.Handlers
{
    public class AddPersonHandler
    {
        ICommandValidator<AddPersonCommand> _validator;

        public AddPersonHandler(ICommandValidator<AddPersonCommand> validator)
        {
            _validator = validator;
        }

        public async Task ExecuteAsync(AddPersonCommand command)
        {
            await _validator.ValidateExecAsync(command);
            if (!_validator.IsValid)
            {
                Console.WriteLine(string.Join(Environment.NewLine, _validator.Errors));
                Console.WriteLine($"{command.Name} de {command.Age} anos não adicionado(a)");
                return;
            }

            Console.WriteLine($"{command.Name} de {command.Age} anos adicionado(a)");
        }
    }
}
