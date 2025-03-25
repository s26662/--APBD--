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
    public Container(string type)
    {
        SerialNumber = $"KON-{type}-{++counter:D5}";
    }

    
    
}