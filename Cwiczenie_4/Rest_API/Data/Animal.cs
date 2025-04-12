namespace Rest_API.Data;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Mass { get; set; }
    public string Color { get; set; }
    public Category Category { get; set; }
}