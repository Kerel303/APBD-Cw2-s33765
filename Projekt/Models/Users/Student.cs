namespace Projekt;

public class Student : User
{
    public Student(string name, string surname) : base(name, surname)
    {
        
    }
    
    public override string ToString()
    {
        return $"Student: {base.ToString()}";
    }
}