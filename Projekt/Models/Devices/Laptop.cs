namespace Projekt;

public class Laptop : Equipment
{
    public string Name = "Laptop";
    public Laptop() : base()
    {
        
    }
    
    public override string ToString()
    {
        return $"{Name} -> Availible: {Availibility}";
    }
}