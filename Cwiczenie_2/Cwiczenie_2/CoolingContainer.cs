namespace Cwiczenie_2;

public class CoolingContainer : Container,IHazardNotifier
{
    public string TypeOfProduct { get; set; }
    public double Temperature { get; set; }

    private static Dictionary<string, double> ProdcutsTemperatures = new()
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
    
    public CoolingContainer(string typeOfProduct, double temperature) : base("C")
    {
        if(!ProdcutsTemperatures.ContainsKey(typeOfProduct))
        {
            throw new ArgumentException("Producent nie jest obsługiwany");
        }

        if (temperature < ProdcutsTemperatures[typeOfProduct])
        {
            throw new ArgumentException($"Temperatura nie może być niższa nic {ProdcutsTemperatures[typeOfProduct]}C, dla produktu {typeOfProduct}");
        }
    }

    public void NotifyHazard(string message)
    {
        throw new NotImplementedException();
    }
}