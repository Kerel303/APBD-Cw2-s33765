namespace Projekt;

public class Camera : Equipment
{
    public string Name = "Camera";
    public Camera() : base()
    {
        
    }

    public override string ToString()
    {
        return $"{Name} -> Availible: {Availibility}";
    }
}