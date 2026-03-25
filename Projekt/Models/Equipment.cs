namespace Projekt.Models;

using Projekt.Models.Devices;
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Laptop), "laptop")]
[JsonDerivedType(typeof(Camera), "camera")]
[JsonDerivedType(typeof(Projector), "projector")]

public class Equipment
{
    public Guid Id { get; }
    public bool Availibility { get; set; }

    public Equipment()
    {
        Id = Guid.NewGuid();
        Availibility = true;
    }

    public override string ToString()
    {
        return $"Equipment: {Id}: Availible: {Availibility}";
    }
}