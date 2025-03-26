namespace Cwiczenie_2;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    public GasContainer(string type) : base("G")
    {
        
    }

    public override void EmptyContainer()
    {
        WeightOfCargo *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        throw new NotImplementedException();
    }
}