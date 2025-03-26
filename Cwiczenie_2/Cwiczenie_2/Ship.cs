namespace Cwiczenie_2;

public class Ship
{
    private List<Container> _containers = new List<Container>();
    public string Name { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxNumberOfContainers { get; set; }
    public int MaxWeightOfContainers { get; set; }

    public Ship(string name, double maxSpeed, int maxNumberOfContainers, int maxWeightOfContainers)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxNumberOfContainers = maxNumberOfContainers;
        MaxWeightOfContainers = maxWeightOfContainers;
    }
    

}