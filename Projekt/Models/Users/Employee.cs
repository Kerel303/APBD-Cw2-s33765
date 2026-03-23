namespace Projekt;

public class Employee : User
{
    public Employee(string name, string surname) : base(name, surname)
    {
        
    }
    
    public override string ToString()
    {
        return $"Employee: {base.ToString()}";
    }
}