using fluentvalidation_adapter_example.Domain.Commands;
using fluentvalidation_adapter_example.Domain.Handlers;
using fluentvalidation_adapter_example.Infra.Validators;

// Criação do Handler com injeção da dependência do validator
var handler = new AddPersonHandler(new AddPersonCommandValidator());

// Comando inválido
Console.WriteLine("Execução do primeiro comando....");

var invalidCommand = new AddPersonCommand("Ab", 17);
await handler.ExecuteAsync(invalidCommand);

Console.WriteLine("-------------------------------------");

// Comando válido
Console.WriteLine("Execução do segundo comando....");

var validCommand = new AddPersonCommand("José", 18);
await handler.ExecuteAsync(validCommand);