using System.Text.Json.Serialization;

namespace Rest_API.Data;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Mass { get; set; }
    public string Color { get; set; }
    public string Category { get; set; }

}