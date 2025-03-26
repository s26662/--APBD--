namespace Cwiczenie_2;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous { get; set;}

    public LiquidContainer(bool isHazardous) : base("L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadContainer(double weight)
    {
       double maxAllowedLoad = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

       if (weight > maxAllowedLoad)
       {
           //Dodanie IHazardNotifier
       }
       
       WeightOfCargo = weight;
       Console.WriteLine($"Załadowano {weight} kg do kontenera {SerialNumber}");
    }


    public void NotifyHazard(string message)
    {
        throw new NotImplementedException();
    }
}