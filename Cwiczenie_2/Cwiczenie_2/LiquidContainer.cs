namespace Cwiczenie_2;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous { get; set;}

    public LiquidContainer(bool isHazardous, double height, double depth, double containerWeight,
        double maxLoad) : base("L", height, depth, containerWeight, maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadContainer(double weight)
    {
       double maxAllowedLoad = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

       if (weight > maxAllowedLoad)
       {
          NotifyHazard($"Przekroczono limit masy w kontenerze {SerialNumber}. Dopuszczalny limit: {maxAllowedLoad}");
          throw new OverfillExeption("Masa ładunku została przekroczona!");
       }
       
       base.LoadContainer(weight);
       Console.WriteLine($"Załadowano {weight}kg do kontenera {SerialNumber}");
    }
    
    public override void EmptyContainer()
    {
        WeightOfCargo *= 0.05;
    }


    public void NotifyHazard(string message)
    {
        Console.WriteLine($"{SerialNumber}: {message}");
    }
}