using Cwiczenie_2;

public class Program
{
    public static void Main(string[] args)
    {
        /*//Demonstracja aplikacji
        
        //1.Utworzenie kontenerowców
        CoolingContainer coolingContainer = new CoolingContainer("Bananas", 13.3,100,200,500,1000);
        LiquidContainer liquidContainer = new LiquidContainer(true, 100, 300, 550, 1500);
        GasContainer gasContainer = new GasContainer(150, 300, 400, 600);
        
        //2.Utworzenie statków
        Ship ship1 = new Ship("Statek 1", 50, 10, 10000);
        Ship ship2 = new Ship("Statek 2", 60, 4, 5000);
        
        //3.Załadowanie kontera
        coolingContainer.LoadContainer(200);
        liquidContainer.LoadContainer(300);
        gasContainer.LoadContainer(400);
        
        //4.Załadowanie statku
        ship1.LoadShip(coolingContainer);
        
        //5.Załadowanie listy kontenerów
        List<Container> containers = new List<Container>(){liquidContainer, gasContainer};
        ship2.LoadShips(containers);
        Console.WriteLine(" ");
        
        //6.Rozałdowanie kontenera
        coolingContainer.EmptyContainer();
        Console.WriteLine(" ");
        
        //7.Usunięcie kontenera ze statku
        ship2.RemoveContainer(gasContainer);
        
        //8. Zastąpenie kontenera innym
        ship1.MoveConatiner(ship1,ship2,"KON-C-00001");
        
        //9.Przeniesienie kontenera
        Ship.SwapContainers(ship1,ship2,"KON-L-00001",KON-C-00001);
        
        // 10. Wypisanie informacji o kontenerze CoolingContainer
        Console.WriteLine(coolingContainer.ToString());

        Console.WriteLine(" ");
        // 11. Wypisanie informacji o statku
        Console.WriteLine(ship1.ToString());
        Console.WriteLine("Informacje o załadunku:");
        foreach (var container in containers)
        {
            Console.WriteLine(container.ToString());            
        }*/
        
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
                      Console.WriteLine(container.SerialNumber);
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
                  Console.WriteLine("6. Załaduje listę kontenerów na statek");
                  Console.WriteLine("7. Rozładuj kontener");
                  Console.WriteLine("8. Usuń kontener ze statku");
                  Console.WriteLine("9. Zamień kontener");
                  Console.WriteLine("10. Przenieś kontener na inny statek");
                  Console.WriteLine("11. Informacje o kontenerze");
                  Console.WriteLine("12. Informacje o statku i jego ładunku");
                  Console.WriteLine("13. Exit");

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
                      int amount = int.Parse(Console.ReadLine());

                      Console.WriteLine("Maksymalna waga konterów: ");
                      double weight = double.Parse(Console.ReadLine());

                      Ship newShip = new Ship(name, speed, amount ,weight);
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
                          }
                          else
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

                      Container newContainer;

                      switch (type)
                      {
                          case "L": 
                              Console.WriteLine("Czy kontener jest niebezpieczny? (true/false): ");
                              bool isHazardous = bool.Parse(Console.ReadLine());
                              newContainer = new LiquidContainer(isHazardous, height, depth, containerWeight, maxLoad);
                              break;

                          case "G": 
                              Console.WriteLine("Ciśnienie kontenera: ");
                              double pressure = double.Parse(Console.ReadLine());
                              newContainer = new GasContainer(pressure, height, depth, containerWeight, maxLoad);
                              break;

                          case "C": 
                              Console.WriteLine("Podaj Typ produktu: ");
                              string product = Console.ReadLine();
                              Console.WriteLine("Temperatura maksymalna dla kontenera: ");
                              double maxTemperature = double.Parse(Console.ReadLine());
                              newContainer = new CoolingContainer(product,maxTemperature, height, depth, containerWeight, maxLoad);
                              break;
                          default:
                              Console.WriteLine("Nieznany typ kontenera. Nie można utworzyć kontenera.");
                              return;
                      }
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
                      Container foundContainer = containers.FirstOrDefault(x => x.SerialNumber == serialNumber);

                      if (foundContainer != null)
                      {
                          var match = System.Text.RegularExpressions.Regex.Match(serialNumber, @"KON-([A-Z])-\d+");
                          if (match.Success)
                          {
                              string containerType = match.Groups[1].Value;

                              switch (containerType)
                              {
                                  case "L":
                                      if (foundContainer is LiquidContainer liquidContainer)
                                      {
                                          Console.WriteLine("Podaj ilość płynu: ");
                                          if (double.TryParse(Console.ReadLine(), out double amountOfLiquid))
                                          {
                                              liquidContainer.LoadContainer(amountOfLiquid);
                                              Console.WriteLine($"Załadowano płyn w ilości: {amountOfLiquid} do kontenera {serialNumber}");
                                          }
                                          else
                                          {
                                                Console.WriteLine("Nieprawidłowa ilość płynu.");
                                          }
                                      }
                                      else
                                      {
                                          Console.WriteLine("Kontener nie jest typu LiquidContainer.");
                                      }
                                      break;

                                    case "G":
                                        if (foundContainer is GasContainer gasContainer)
                                        {
                                            Console.WriteLine("Podaj ilość gazu do załadowania: ");
                                            if (double.TryParse(Console.ReadLine(), out double amountOfGas))
                                            {
                                                gasContainer.LoadContainer(amountOfGas);
                                                Console.WriteLine($"Załadowano gaz w ilości {amountOfGas} do kontenera {serialNumber}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Nieprawidłowa ilość gazu.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Kontener nie jest typu GasContainer.");
                                        }
                                        break;

                                    case "C":
                                        if (foundContainer is CoolingContainer coolingContainer)
                                        {
                                            Console.WriteLine("Podaj temperaturę kontenera: ");
                                            if (double.TryParse(Console.ReadLine(), out double temperature))
                                            {
                                                Console.WriteLine("Podaj nazwę produktu do załadowania: ");
                                                string productToLoad = Console.ReadLine();
                                                Console.WriteLine("Podaj ilość produktu do załadowania:");
                                                if (double.TryParse(Console.ReadLine(), out double amountOfProduct))
                                                {
                                                    if (CoolingContainer.ProdcutsTemperatures.ContainsKey(productToLoad))
                                                    {
                                                        double requiredTemperature = CoolingContainer.ProdcutsTemperatures[productToLoad];
                                                        if (temperature > requiredTemperature)
                                                        {
                                                            coolingContainer.LoadContainer(amountOfProduct);
                                                            Console.WriteLine($"Załadowano {productToLoad} w ilości {amountOfProduct} do kontenera {serialNumber}. Temperatura kontenera: {temperature}");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Nie można załadować tego produktu, temperatura kontenera jest za niska.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nie znaleziono tego produktu.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nieprawidłowa ilość produktu.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Nieprawidłowa temperatura.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Kontener nie jest typu CoolingContainer.");
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("Nieznany typ kontenera.");
                                        break;
                              }
                          }
                          else
                          {
                              Console.WriteLine("Nieprawidłowy format numeru seryjnego.");
                          }
                      }
                      else
                      {
                          Console.WriteLine("Nie znaleziono kontenera.");
                      }
                      break;
                  case "5":
                      Console.Clear();
                      foreach (var ship in ships)
                      {
                          Console.WriteLine(ship.ToString());
                      }
                      Console.WriteLine("Podaj nazwę statku: ");
                      string shipName = Console.ReadLine();
                      Ship foundShipToLoad = ships.Find(x => x.Name == shipName);
                      if (foundShipToLoad != null)
                      {
                          foreach (var con in containers)
                          {
                              Console.WriteLine(con.ToString());
                          }
                          Console.WriteLine("Podaj SerialNumber kontenera: ");
                          string serialNumberContainer = Console.ReadLine();
                          Container foundContainerToLoad = containers.Find(x => x.SerialNumber == serialNumberContainer);
                          if (foundContainerToLoad != null)
                          {
                              foundShipToLoad.LoadShip(foundContainerToLoad);
                              containers.Remove(foundContainerToLoad);
                              Console.WriteLine($"Załadowano konterner {serialNumberContainer}, na statek {shipName}");
                          }
                          else
                          {
                              Console.WriteLine("Nie znaleziono kontenera");
                          }
                      }
                      else
                      {
                          Console.WriteLine("Nie znaleziono statku");
                      }

                      break;
                  case "6":
                      Console.Clear();
                      foreach (var ship in ships)
                      {
                          Console.WriteLine(ship.ToString());
                      }
                      Console.WriteLine("Podaj nazwę statku: ");
                      string shipToLoad = Console.ReadLine();
                      Ship shipToLoadListConainers = ships.Find(x => x.Name == shipToLoad);
                      if (shipToLoadListConainers != null)
                      {
                          foreach (var con in containers)
                          {
                              Console.WriteLine(con.ToString());
                          }
                          Console.WriteLine("Podaj SerialNumber kontenerów do załadowania na statek: ");
                          string inputContainer = Console.ReadLine();
                          string[] containerN = inputContainer.Split(',');
                          List<Container> containerList = new List<Container>();

                          foreach (var containerNumber in containerN)
                          {
                              string trimmedNumber = containerNumber.Trim();
                              Container foundContainerToLoad = containers.Find(x => x.SerialNumber == trimmedNumber);

                              if (foundContainerToLoad != null)
                              {
                                  containerList.Add(foundContainerToLoad);
                              }
                              else
                              {
                                  Console.WriteLine("Nie znaleziono kontenera");
                              }
                          }

                          shipToLoadListConainers.LoadShips(containerList);
                          Console.WriteLine($"Kontenery zostały załadowane na statek: {shipToLoadListConainers.Name}");
                      }
                      else
                      {
                          Console.WriteLine("Nie znaleziono statku");
                      }

                      break;
                  case "7":
                      Console.Clear();
                      foreach (var container in containers)
                      {
                          Console.WriteLine(container.ToString());
                      }

                      Console.WriteLine("Podaj SerialNumber kontenera: ");
                      string serialNumber2 = Console.ReadLine();
                      Container foundContainer2 = containers.Find(x => x.SerialNumber == serialNumber2);
                      if (foundContainer2 != null)
                      {
                          if (foundContainer2 is LiquidContainer liquidContainer)
                          {
                              liquidContainer.EmptyContainer();
                              Console.WriteLine($"Kontener {serialNumber2} został opróżniony");
                          }
                          else if (foundContainer2 is GasContainer gasContainer)
                          {
                              gasContainer.EmptyContainer();
                              Console.WriteLine($"Kontener {serialNumber2} został opróżniony");
                          }
                          else if (foundContainer2 is CoolingContainer coolingContainer)
                          {
                              coolingContainer.EmptyContainer();
                              Console.WriteLine($"Kontener {serialNumber2} został opróżniony");
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
                  case "8":
                      Console.Clear();
                      Console.WriteLine("Podaj nazwę statku: ");
                      string shipName1 = Console.ReadLine();
                      Ship foundShipToLoad1 = ships.Find(x => x.Name == shipName1);
                      if (foundShipToLoad1 != null)
                      {
                          Console.WriteLine("Podaj SerialNumber kontenera: ");
                          string serialNumberContainer = Console.ReadLine();
                          Container foundContainerToLoad =
                              containers.Find(x => x.SerialNumber == serialNumberContainer);
                          if (foundContainerToLoad != null)
                          {
                              foundShipToLoad1.RemoveContainer(foundContainerToLoad);
                              containers.Add(foundContainerToLoad);
                          }
                          else
                          {
                              Console.WriteLine("Nie znaleziono kontenera");
                          }
                      }
                      else
                      {
                          Console.WriteLine("Nie znaleziono statku");
                      }

                      break;
                  case "9":
                      Console.Clear();
                      foreach (var ship in ships)
                      {
                          Console.WriteLine(ship.ToString());
                      }

                      Console.WriteLine("Podaj nazwę pierwszego statku: ");
                      string firstShip1 = Console.ReadLine();
                      Ship foundShipToMove = ships.Find(x => x.Name == firstShip1);
                      if (foundShipToMove != null)
                      {
                          Console.WriteLine("Podaj nazwę drugiego statku: ");
                          string secondShip = Console.ReadLine();
                          Ship foundShipToMove2 = ships.Find(x => x.Name == secondShip);

                          if (foundShipToMove2 != null)
                          {
                              Console.WriteLine("Lista Konternerów z pierwszego statku: ");
                              foreach (var container in foundShipToMove._containers)
                              {
                                  Console.WriteLine(container.ToString());
                              }

                              Console.WriteLine("Podaj Serial Number kontener do przeniesienia z pierwszego statku: ");
                              string firstMoveContainer = Console.ReadLine();
                              Container? firstFoundContainer =
                                  foundShipToMove._containers.Find(x => x.SerialNumber == firstMoveContainer);

                              double newShipWeight = foundShipToMove2._containers.Sum(c => c.ContainerWeight) +
                                                     firstFoundContainer.ContainerWeight;

                              if (newShipWeight > foundShipToMove2.MaxWeightOfContainers)
                              {
                                  Console.WriteLine("Zamiana niemożliwa - przekroczono maksymalną wagę jednego ze statków.");
                                  break;
                              }

                              Ship.MoveContainer(foundShipToMove, foundShipToMove2, firstMoveContainer);
                              Console.WriteLine( $"Zamieniono kontener {firstMoveContainer} przeniesiono go między statkami {foundShipToMove} <--> {foundShipToMove2}.");
                          }else
                          {
                              Console.WriteLine("Nie znaleziono drugiego statku");
                          }
                      }
                      else
                      {
                          Console.WriteLine("Nie znaleziono pierwszego statku");
                      }

                      break;
                  case "10":
                      Console.Clear();
                      foreach (var ship in ships)
                      {
                          Console.WriteLine(ship.ToString());
                      }
                      Console.WriteLine("Podaj nazwę pierwszego statku: ");
                      string firstShip = Console.ReadLine();
                      Ship foundShipToLoad2 = ships.Find(x => x.Name == firstShip);
                      if (foundShipToLoad2 != null)
                      {
                          Console.WriteLine("Podaj nazwę drugiego statku: ");
                          string secondShip = Console.ReadLine();
                          Ship foundShipToLoad3 = ships.Find(x => x.Name == secondShip);

                          if (foundShipToLoad3 != null)
                          {
                              Console.WriteLine("Lista Konternerów z pierwszego statku: ");
                              foreach (var container in foundShipToLoad2._containers)
                              {
                                  Console.WriteLine(container.ToString());
                              }
                              Console.WriteLine("Podaj Serial Number kontener do przeniesienia z pierwszego statku: ");
                              string firstMoveContainer = Console.ReadLine();
                              Container? firstFoundContainer = foundShipToLoad2._containers.Find(x => x.SerialNumber == firstMoveContainer);

                              Console.WriteLine("Lista Konternerów z drugiego statku: ");
                              foreach (var container in foundShipToLoad3._containers)
                              {
                                  Console.WriteLine(container.ToString());
                              }
                              Console.WriteLine("Podaj Serial Number kontener do przeniesienia z drugiego statku: ");
                              string secondMoveContainer = Console.ReadLine();
                              Container? secondFoundContainer = foundShipToLoad2._containers.Find(x => x.SerialNumber == secondMoveContainer);

                              double firstShipWeight = foundShipToLoad2._containers.Sum(c => c.ContainerWeight) - firstFoundContainer.ContainerWeight + secondFoundContainer.ContainerWeight;
                              double secondShipWeight = foundShipToLoad3._containers.Sum(c => c.ContainerWeight) - secondFoundContainer.ContainerWeight + firstFoundContainer.ContainerWeight;

                              if (firstShipWeight > foundShipToLoad2.MaxWeightOfContainers || secondShipWeight > foundShipToLoad3.MaxWeightOfContainers) {
                                  Console.WriteLine("Zamiana niemożliwa - przekroczono maksymalną wagę jednego ze statków.");
                                  break;
                              }
                              
                              Ship.SwapContainers(foundShipToLoad2, foundShipToLoad3, firstFoundContainer, secondFoundContainer);
                              
                              Console.WriteLine($"Zamieniono kontenery {firstFoundContainer} <--> {secondFoundContainer} między statkami {foundShipToLoad2} i {foundShipToLoad3}.");
                          }
                          else
                          {
                              Console.WriteLine("Nie znaleziono statku");
                          }
                      }
                      break;
                  case "11":
                      Console.Clear();
                      foreach (var conteiner in containers)
                      {
                          Console.WriteLine(conteiner.ToString());
                      }
                      Console.WriteLine("Podaj SerialNumber kontenera: ");
                      string serialNumberC = Console.ReadLine();
                      Container foundContainerToInfo = containers.Find(x => x.SerialNumber == serialNumberC);
                      if (foundContainerToInfo != null)
                      {
                          foreach (var container in containers)
                          {
                              Console.WriteLine("Informacje o kontenerze: ");
                              Console.WriteLine(container.ToString() +"\n");
                          }
                         
                      }
                      else
                      {
                          Console.WriteLine("Nie znaleziono kontenera");
                      }
                      break;
                  case "12":
                      Console.Clear();
                      foreach (var ship in ships)
                      {
                          Console.WriteLine(ship.ToString());
                      }
                      Console.WriteLine("Podaj nazwę statku: ");
                      string shipNameToInfo = Console.ReadLine();
                      Ship foundShipNameToInfo = ships.Find(x => x.Name == shipNameToInfo);
                      if (foundShipNameToInfo != null)
                      {
                          Console.WriteLine("Informacje o statku i jego załadunku:");
                          Console.WriteLine(foundShipNameToInfo.ToString());

                          if (foundShipNameToInfo._containers.Any())
                          {
                              foreach (var container in foundShipNameToInfo._containers)
                              {
                              
                                  Console.WriteLine(container.ToString() + "\n");
                              }
                          }
                          else
                          {
                              Console.WriteLine("Aktualnie brak kontenerów\n");
                          }
                      }
                      else
                      {
                          Console.WriteLine("Nie znaleziono statku\n");
                      }
                      break;
                  case "13":
                      running = false;
                      break;
                  default:
                      Console.WriteLine("Nieznana opcja, wprowadz jeszcze raz");
                      break;

              }

          }

    }
    
} 