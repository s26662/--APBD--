namespace Cwiczenie_2;

public class Container
{
    private static int counter = 0;
    public string SerialNumber { get; set; } //Numer seryjny
    public double WeightOfCargo { get; set; } //Masa ładunku
    public double Height { get; set; } //Wysokość
    public double Depth { get; set; } //Głębokość
    public double ContainerWeight { get; set; } //Waga własna
    public double MaxLoad { get; set; } //Maksymalna ładowność


    //Konstruktor 
    public Container(string type, double height, double depth, double containerWeight, double maxLoad)
    {
        SerialNumber = GenerateSerialNumber(type);
        WeightOfCargo = 0.0;
        Height = height;
        Depth = depth;
        ContainerWeight = containerWeight;
        MaxLoad = maxLoad;
    }
    
    public static string GenerateSerialNumber(string type)
    {
        counter++;
        return $"KON-{type}-{counter:D5}";
    }
    
    public virtual void LoadContainer(double weight)
    {
        if (WeightOfCargo + weight > MaxLoad)
        {
            throw new OverfillExeption($"Przekroczono maksymalną ładowność konternera {SerialNumber}!");
        }
        
        WeightOfCargo += weight;
        Console.WriteLine($"Załadowano {weight} kg do kontenera {SerialNumber}");
    }
    
    public virtual void EmptyContainer()
    {
        if (WeightOfCargo == 0)
        {
            Console.WriteLine("Kontener jest pusty");
        }

        WeightOfCargo = 0.0;
        Console.WriteLine($"Kontener {SerialNumber} został opróżniony");
    }

    public virtual string ToString()
    {
        return
            $"{SerialNumber} (Masa ładunku={WeightOfCargo}kg, Wysokość={Height}cm, Głębokość={Depth}cm, Waga={ContainerWeight}kg, Maksymalna ładowność={MaxLoad}kg)";
    }

  

}