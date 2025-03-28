namespace Cwiczenie_2;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    public GasContainer(double pressure, double height, double depth, double containerWeight, 
        double maxLoad) : base("G", height, depth, containerWeight, maxLoad)
    {
        Pressure = pressure;
    }

    public override void LoadContainer(double weight)
    {
        if (weight > MaxLoad)
        {
            NotifyHazard($"Przekroczono limit masy w kontenerze {SerialNumber}. Dopuszczalny limit: {MaxLoad}");
            throw new OverfillExeption("Masa ładunku została przekroczona!");
        }
       
        base.LoadContainer(weight);
        Console.WriteLine($"Załadowano {weight} kg do kontenera {SerialNumber}");
        
    }

    public void EmptyContainer()
    {
        WeightOfCargo *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"{SerialNumber}: {message}");
    }
    
    public override string ToString()
    {
        return $"{SerialNumber} (Masa ładunku={WeightOfCargo}kg, Ciśnienie={Pressure}atm , Wysokość={Height}cm, Głębokość={Depth}cm, Waga={ContainerWeight}kg, Maksymalna ładowność={MaxLoad}kg)";
    }
}