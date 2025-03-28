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
        if (_containers.Count >= MaxNumberOfContainers || _containers.Sum(c => c.WeightOfCargo) >= MaxWeightOfContainers)
        {
            throw new Exception($"Statek {container} osiągnął limit kontenerów lub wagi");
        }
        _containers.Add(container);
    }

    public void LoadShips(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadShip(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }

    public static void MoveContainer(Ship ship1, Ship ship2, string serialNumberContainer)
    {
        Container? container = ship1._containers.Find(c => c.SerialNumber == serialNumberContainer);
        if (container == null)
        {
            Console.WriteLine($"Nie odnaleziono kontenera {serialNumberContainer} na statku {ship1.Name}");
        }

        if (ship2._containers.Count >= ship2.MaxNumberOfContainers)
        {
            Console.WriteLine($"Nie odnaleziono kontenera {serialNumberContainer} na statku {ship2.Name}");  
        }

        ship1._containers.Remove(container);
        ship2._containers.Add(container);

        Console.WriteLine($"Kontener {container.SerialNumber} został przeniesiony ze statku {ship1.Name} na statek {ship2.Name}");

    }

    public static void SwapContainers(Ship ship1, Ship ship2, Container oldSerial, Container newSerial)
    {
        Container? container1 = ship1._containers.Find(c => c.SerialNumber == oldSerial.SerialNumber);
        Container? container2 = ship2._containers.Find(c => c.SerialNumber == newSerial.SerialNumber);

        if (ship1 == null || ship2 == null)
        {
            Console.WriteLine("Nie znaleziono statków które posiadają kontenery");
        }
        
        ship1._containers.Remove(container1);
        ship2._containers.Remove(container2);

        ship1._containers.Add(container2);
        ship2._containers.Add(container1);

        Console.WriteLine($"Kontenery {container1.SerialNumber} i {container2.SerialNumber} zostały zamienione.");
    }

    public override string ToString()
    {
        return
            $"{Name} (speed = {MaxSpeed}, max containers = {MaxNumberOfContainers}, max weight = {MaxWeightOfContainers})";
    }
}