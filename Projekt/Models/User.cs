namespace Projekt;

using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Student), "student")]
[JsonDerivedType(typeof(Employee), "employee")]

public class User
{
    public Guid Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public User(string name, string surname)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} {Surname}";
    }
}