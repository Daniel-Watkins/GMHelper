using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GMHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            (new UserInterface()).RunProgram();
        }

    }
    enum MenuOptions
    {
        QUIT = 1,
        ADDITEM,
        FINDITEM,
        SHORTESTROUTE,
        ADDLOCATION,
    }
    class UserInterface
    {
        ItemHashTable itemHashTable = new ItemHashTable();
        LocationGraph locationGraph = new LocationGraph();
        public void RunProgram()
        {
            int Choice;
            do
            {
                Console.WriteLine("Welcome to GM Helper!");
                Console.WriteLine("Main Menu");
                Console.WriteLine("{0} : End the program", (int)MenuOptions.QUIT);
                Console.WriteLine("{0} : Add an Item", (int)MenuOptions.ADDITEM);
                Console.WriteLine("{0} : Find an Item", (int)MenuOptions.FINDITEM);
                Console.WriteLine("{0} : Find Shortest Route between two locations", (int)MenuOptions.SHORTESTROUTE);
                Console.WriteLine("{0} : Add a Location", (int)MenuOptions.ADDLOCATION);
                Console.WriteLine("Enter one of the above menu options and hit return");
                if (!Int32.TryParse(Console.ReadLine(), out Choice))
                {
                    Console.WriteLine("You need to type in a valid, whole number!");
                    continue;
                }
                switch ((MenuOptions)Choice)
                {
                    case MenuOptions.QUIT:
                        Console.WriteLine("Thank you for using GM Helper!");
                        break;
                    case MenuOptions.ADDITEM:
                        Console.WriteLine("Add an Item Chosen");
                        this.AddItem();
                        break;
                    case MenuOptions.FINDITEM:
                        Console.WriteLine("Find an Item Chosen");
                        this.FindItem();
                        break;
                    case MenuOptions.SHORTESTROUTE:
                        Console.WriteLine("Find Shortest Route Chosen");
                        this.ShortestDistance();
                        break;
                    case MenuOptions.ADDLOCATION:
                        Console.WriteLine("Add a Location Chosen");
                        this.AddLocation();
                        break;
                    default:
                        Console.WriteLine("I'm sorry, but that is not a valid menu option");
                        break;

                }
            } while (Choice != (int)MenuOptions.QUIT);
        }
        
        public void AddItem()
        {
            Console.WriteLine("Add an Item");

            Console.WriteLine("Item name?");
            string name = Console.ReadLine();

            Console.WriteLine("Item description?");
            string description = Console.ReadLine();

            itemHashTable.hashAddItem(name, description);
        }

        public void FindItem()
        {
            Console.WriteLine("Find an Item");

            Console.WriteLine("Item name?");
            string name = Console.ReadLine();

            itemHashTable.hashFindItem(name);
        }
        
        public void ShortestDistance()
        {
            Console.WriteLine("Shortest Distance between two points");

            Console.WriteLine("Starting Location");
            string start = Console.ReadLine();

            Console.WriteLine("End Location?");
            string end = Console.ReadLine();

            locationGraph.Dijkstra(start, end);
        }
        public void AddLocation()
        {
            Console.WriteLine("Add Location");

            Console.WriteLine("Location name?");
            string name = Console.ReadLine();
            locationGraph.addLocation();

        }
    }
}
