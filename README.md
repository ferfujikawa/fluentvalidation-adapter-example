# fluentvalidation-adapter-example

Projeto de exemplo de criação de adaptador para utilização do pacote [FluentValidation](https://github.com/FluentValidation/FluentValidation).

## Explicação quanto à arquitetura

Os namespaces `Domain` e `Infra` foram criados no mesmo projeto para facilitar a compreensão, porém estão implementados de forma que as classes de `Domain` não dependem de nenhuma implementação de `Infra`.

## Utilização

Para adicionar um novo validador, crie uma classe que extenda de `AbstractCommandValidator<T>` e implemente `ICommandValidator<T>`, onde `T` é a classe do objeto a ser validado.

Exemplo do validador `AddPersonCommandValidator`:

```c#
public class AddPersonCommandValidator : AbstractCommandValidator<AddPersonCommand>
{
    protected override void LoadRules()
    {
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres");
        RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage("Este sistema permite apenas o cadastro de pessoas com no mínimo 18 anos");
    }
}
```

Na classe onde o validador será utilizado, receba por injeção de dependência um objeto que implemente a interface `ICommandValidator<T>`, faça a chamada do método de validação e obtenha os erros encontrados na validação, caso existam.

```c#
private ICommandValidator<AddPersonCommand> _validator;

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
```