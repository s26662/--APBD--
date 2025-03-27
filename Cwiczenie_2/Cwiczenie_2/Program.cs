using Cwiczenie_2;

public class Program
{
    public static void Main(string[] args)
    {
        List<Container> containers = new List<Container>();
        List<Ship> ships = new List<Ship>();
        bool running = true;
        
        while (running)
        {
            Console.WriteLine("Lista kontenerowców:");

            if (ships.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var ship in ships)
                {
                    Console.WriteLine(ship.ToString());
                }
            }
            
            Console.WriteLine("\nLista kontenerów: ");
            if (containers.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var container in containers)
                {
                    Console.WriteLine(container.ToString());
                }
            }


            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            if (ships.Count > 0)
            {
                Console.WriteLine("2. Usuń kontenerowiec");
                Console.WriteLine("3. Dodaj kontener");
                Console.WriteLine("4. Załaduj kontener");
                Console.WriteLine("5. Załaduj kontener na statek");
                Console.WriteLine("6. Rozładuj kontener");
                Console.WriteLine("7. Usuń kontener ze statku");
                Console.WriteLine("8. Zamień kontener");
                Console.WriteLine("9. Przenieś kontener na inny statek");
                Console.WriteLine("10. Informacje o kontenerze");
                Console.WriteLine("11. Informacje o statku i jego ładunku");
                Console.WriteLine("12. Exit");
                
            }
            

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Nazwa konterowca: ");
                    string name = Console.ReadLine();
                    
                    Console.WriteLine("Maksymalna prędkość kontenerowca: ");
                    int speed = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Maksymalna liczba kontenerów: ");
                    double amount = double.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Maksymalna waga konterów: ");
                    double weight = double.Parse(Console.ReadLine());
                    
                    Ship newShip = new Ship(name,amount ,speed, weight);
                    ships.Add(newShip);
                    Console.WriteLine($"\nDodano nowy kontenerowiec: {name}");
                    break;
                case "2":
                    Console.Clear();
                    if (ships.Count > 0)
                    {
                        Console.WriteLine("Nazwa kontenera do usunięcia: ");
                        string RemoveShip = Console.ReadLine();
                        Ship foundShip = ships.Find(x => x.Name == RemoveShip);
                        if (foundShip != null)
                        {
                            ships.Remove(foundShip);
                            Console.WriteLine($"\nUsunięto kontenerowiec: {RemoveShip}");
                        }else
                        {
                            Console.WriteLine("\nNie znaleziono kontenera");
                        }
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Typ kontera: ");
                    string type = Console.ReadLine();
                    
                    Console.WriteLine("Wysokość kontenera: ");
                    double height = double.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Głębokość kontenera: ");
                    double depth = double.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Waga kontenera: ");
                    double containerWeight = double.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Maksymalna ładowność kontenera: ");
                    double maxLoad = double.Parse(Console.ReadLine());
                    
                    Container newContainer = new Container(type, height, depth, containerWeight, maxLoad);
                    containers.Add(newContainer);
                    Console.WriteLine($"\nDodano nowy kontener: {newContainer.SerialNumber}");
                    break;
                case "4":
                    Console.Clear();
                    foreach (var container in containers)
                    {
                        Console.WriteLine(container.ToString());
                    }
                    Console.WriteLine("Podaj SerialNumber kontenera: ");
                    string serialNumber = Console.ReadLine();
                    Container foundContainer = containers.Find(x => x.SerialNumber == serialNumber);
                    string splitType = serialNumber.Split('-')[1];
                    if (foundContainer != null)
                    {
                        if (splitType == "L")
                        {
                            Console.WriteLine("Podaj rodzaj płynu: ");
                            string liqudi = Console.ReadLine();
                            Console.WriteLine("Podaj ilość płynu: ");
                            double amountOfLiqudi = double.Parse(Console.ReadLine());
                            foundContainer.LoadContainer(amountOfLiqudi);
                            Console.WriteLine($"Załadowano {liqudi} w ilości {amountOfLiqudi} do kontenera {serialNumber}");
                        }
                        else if (splitType == "G")
                        {
                            Console.WriteLine("Podaj ilośc Gazu do załadowania: ");
                            double amountOfGas = double.Parse(Console.ReadLine());
                            foundContainer.LoadContainer(amountOfGas);
                            Console.WriteLine($"Załadowano gaz w ilości {amountOfGas} do kontenera {serialNumber}");
                        }
                        else if (splitType == "C")
                        {
                            Console.WriteLine("Podaj temeprature kontenera: ");
                            double temperature = double.Parse(Console.ReadLine());
                            Console.WriteLine("Podaj nazwę produkut do załadowania: ");
                            string productToLoad = Console.ReadLine();
                            Console.WriteLine("Podaj ilość produktu do załadowania:");
                            double amountOfProduct = double.Parse(Console.ReadLine());
                            if (CoolingContainer.ProdcutsTemperatures.ContainsKey(productToLoad))
                            {
                                double requiredTemperature = CoolingContainer.ProdcutsTemperatures[productToLoad];
                                if (temperature > requiredTemperature)
                                {
                                    foundContainer.LoadContainer(amountOfProduct);
                                    Console.WriteLine($"Załadowano {productToLoad} w ilości {amountOfProduct} do kontenera {serialNumber}. Temperatura kontenera: {temperature}");
                                }
                                else
                                {
                                    Console.WriteLine("Nie można załadować tego produktu, temperatura kontenera jest za niska");
                                }
                            }else
                            {
                                Console.WriteLine("Nie znaleziono tego produktu");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nie znany typ kontera");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono kontenera");
                    }

                    break;
                case "5":
                    //Dodać logikę na załadowanie stataktu kontenerami
                    
                    break;
                case "6":
                    //Dodać logike na rozładowanie statku
                    break;
                case "7":
                    //Logika na usunięcie kontera ze statku ale nie z listy
                    break;
                case "8":
                    //logika na zmianę kontenera z listy(chodzi o to że podaje serialNo i zamieniam go z tym co jest już na statku)
                    break;
                case "9":
                    //logika na przeniesienie kontenera na inny statek
                    break;
                case "10":
                    //zwrócić informacje o kontenerze
                    break;
                case "11":
                    //zwrócić informacje o statku i jaki ładunek przewozi
                    break;
                case "12":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja, wprowadz jeszcze raz");
                    break;
                
            }
            
        }


    }
}