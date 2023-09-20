namespace Reslogg
{
    class Program
    {
        public class Destinations
        {
            public string Destination;
            public DateTime Date;
            public int Distance;
            public int Time;
            public Destinations(string dest, DateTime date, int distance, int time)
            {
                Destination = dest;
                Date = date;
                Distance = distance;
                Time = time;
            }
            public Destinations()
            {

            }

        }
        static List<Destinations> destinations = new();
        public static void Main(string[] args)
        {
            while (true)
            {
                showMenu();
                Destinations ObDestination = new Destinations();
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "A":
                        {
                            string st = Getstring();
                            DateTime date = new DateTime();
                            date = TryToGetDate();
                            int num = TryGetInt("Enter how many KM will it take ");
                            int num1 = TryGetInt("Enter how many hours will it take");
                            ObDestination = new Destinations(st, date, num, num1);
                            destinations.Add(ObDestination);
                            break;
                        }
                    case "B":
                        {
                            foreach (var item in destinations)
                            {
                                Console.WriteLine("Destination is: {0},  Date is: {1:d-MMM-yyyy}, Distance is: {2} , Time is: {3}",
                                    item.Destination, item.Date, item.Distance, item.Time);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "C":
                        {
                            Console.WriteLine("wich one you destination do you want delet?");
                            string delet = Console.ReadLine();
                            for (int i = 0; i < destinations.Count; i++)
                            {
                                if (destinations[i].Destination == delet)
                                {
                                    destinations.Remove(destinations[i]);
                                }
                            }


                            break;
                        }
                    case "D":
                        {
                            foreach (var item in destinations)
                            {
                                Console.WriteLine("Destination is: {0},  Date is: {1:d-MMM-yyyy}, Distance is: {2} , Time is: {3}",
                                    item.Destination, item.Date, item.Distance, item.Time);
                            }

                            string Chose = string.Empty;
                            do
                            {
                                Console.WriteLine("wich one you destination do you want edit?");
                                string edit = Console.ReadLine();
                                for (int i = 0; i < destinations.Count; i++)
                                {
                                    if (destinations[i].Destination == edit)
                                    {
                                        Console.WriteLine("Edite dsetions");
                                        string st = Getstring();
                                        destinations[i].Destination = st;
                                        DateTime date = new DateTime();
                                        date = TryToGetDate();
                                        destinations[i].Date = date;
                                        int num = TryGetInt("Enter how many KM will it take ");
                                        destinations[i].Distance = num;
                                        int num1 = TryGetInt("Enter how many hours will it take");
                                        destinations[i].Time = num1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That was wron information!");
                                    }
                                    Console.WriteLine("Do you want to continue? Perss y ");
                                    Chose = Console.ReadLine();

                                }
                            } while (Chose == "y" || Chose == "Y");

                            break;

                        }

                    case "Q":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default: break;
                }

            }
        }


        static void showMenu()
        {
            Console.Clear();
            Console.WriteLine("Chose A if you want to input a new destination \n" + "Chose B if you want to show all you destination \n" +
                                 "Chose C if you want to remove a destination \n" + "Chose D if you want to edit you input\n" +
                                   "Chose Q if you want to exit from program \n");
        }
        static string Getstring()
        {
            Console.WriteLine("Enter you destination ");
            string input = Console.ReadLine();
            return input;

        }
        static DateTime TryToGetDate()
        {
            DateTime date = new DateTime();
            while (true)
            {
                Console.Write("Enter a date (YYYY-MM-DD): ");
                string input = Console.ReadLine();
                try
                {
                    date = DateTime.Parse(input);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("try agine");
                }

            }
            return date;
        }
        static int TryGetInt(string massege)
        {
            int result = 0;

            bool success = false;

            while (success == false)
            {
                Console.WriteLine(massege);

                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {

                    try
                    {
                        if (result < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {

                            success = true;
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Not minus value");
                    }
                }
                //else
                //{
                //    Console.WriteLine("It is wron, try agine ! OR press ESC To escape  or press another key");
                //    var ch = Console.ReadKey();
                //    if (ch.Key == ConsoleKey.Escape)
                //    {
                //        break;
                //    }
                //}
            }


            return result;
        }

    }
}