namespace Cwiczenie_2;

public class CoolingContainer : Container,IHazardNotifier
{
    public string TypeOfProduct { get; set; }
    public double Temperature { get; set; }

    public static Dictionary<string, double> ProdcutsTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };
    
    public CoolingContainer(string typeOfProduct, double temperature, double height, double depth, 
        double containerWeight, double maxLoad) : base("C", height, depth, containerWeight, maxLoad)
    {
        if(!ProdcutsTemperatures.ContainsKey(typeOfProduct))
        {
            NotifyHazard($"Nieznany produkt");
            throw new OverfillExeption("Producent nie jest obsługiwany");
            
        }
        TypeOfProduct = typeOfProduct;
        
        if (temperature < ProdcutsTemperatures[typeOfProduct])
        {
            NotifyHazard($"Temperatura kontenera {SerialNumber} jest zbyt zniska dla produktu{typeOfProduct}");
            throw new OverfillExeption($"Temperatura nie może być niższa nic {ProdcutsTemperatures[typeOfProduct]}C, dla produktu {typeOfProduct}");
        }
        Temperature = temperature;
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
        base.EmptyContainer();
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"{SerialNumber}: {message}");
    }
}