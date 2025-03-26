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
                Console.WriteLine("7. Zamień kontener");
                Console.WriteLine("8. Przenieś na kontener na inny statek");
                Console.WriteLine("9. Informacje o kontenerze");
                Console.WriteLine("10. Informacje o stateku i jego ładunku");
                Console.WriteLine("11. Exit");
                
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
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case "9":
                    break;
                case "10":
                    break;
                case "11":
                    break;
                case "12":
                    break;
                
            }
            
        }


    }
}