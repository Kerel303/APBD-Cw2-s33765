namespace Projekt;

public class Projector : Equipment
{
    public string Name = "Projector";
    public Projector() : base()
    {
        
    }
    
    public override string ToString()
    {
        return $"{Name} -> Availible: {Availibility}";
    }
}