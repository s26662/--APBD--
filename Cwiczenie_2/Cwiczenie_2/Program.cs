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
            Console.WriteLine("1. Dodaj kontener");
            if (ships.Count > 0)
            {
                Console.WriteLine("2.Usuń kontenerowiec");
                Console.WriteLine("3.Dodaj kontener");
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
                    Console.WriteLine($"Dodano nowy kontener: {name}");
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
                            Console.WriteLine($"Usunięto kontenerowiec: {RemoveShip}");
                        }else
                        {
                            Console.WriteLine("Nie znaleziono kontenera");
                        }
                    }
                    break;
                case "3":
                    break;
                
            }
            
        }


    }
}