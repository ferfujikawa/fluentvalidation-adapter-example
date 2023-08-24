namespace fluentvalidation_adapter_example.Domain.Commands
{
    public class AddPersonCommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; set; }

        public AddPersonCommand(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }
    }
}
