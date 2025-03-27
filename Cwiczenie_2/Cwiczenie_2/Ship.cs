namespace Cwiczenie_2;

public class Ship
{
    public List<Container> _containers = new List<Container>();
    public string Name { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxNumberOfContainers { get; set; }
    public double MaxWeightOfContainers { get; set; }

    public Ship(string name, double maxSpeed, int maxNumberOfContainers, double maxWeightOfContainers)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxNumberOfContainers = maxNumberOfContainers;
        MaxWeightOfContainers = maxWeightOfContainers;
    }

    public void LoadShip(Container container)
    {
        if (_containers.Count < MaxNumberOfContainers || _containers.Sum(c => c.WeightOfCargo) < MaxWeightOfContainers)
        {
            throw new Exception($"Statek {container} osiągnął limit kontenerów lub wagi");
        }
        _containers.Add(container);
    }

    public void UnloadShip(Container container)
    {
        _containers.Remove(container);
    }

    public override string ToString()
    {
        return
            $"{Name} (speed = {MaxSpeed}, max containers = {MaxNumberOfContainers}, max weight = {MaxWeightOfContainers})";
    }
}