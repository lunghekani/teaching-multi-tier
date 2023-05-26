using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLayer;
namespace teaching_multi_tier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // creating a loop so the program runs until the user wants to exit
            while (true)
            {

                DisplayMenu();
                // getting an option from the user
                string option = Console.ReadLine();

                // this is the logic of the application
                BusinessLogic objBusiness = new BusinessLogic();
                List<string> list = new List<string>();
                list = objBusiness.SendListToPresentation();
                if (option == "1")
                {
                    Console.Clear();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (option == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a domain, e.g .com");
                    string domain = Console.ReadLine(); // getting the domain from the user
                    objBusiness.SearchByDomain(domain);

                    Console.WriteLine("Would you like to export the list? Y - Yes N - No");
                    string userChoice = Console.ReadLine();
                    if (userChoice =="Y")
                    {
                        objBusiness.SendListOfDomainsToDataLayer(domain);
                    }
                }
                else if (option == "3")
                {
                    Console.Clear();
                    Console.WriteLine("The average age of everyone in the file is " + objBusiness.CalulateAverageAge());
                    

                }
                else if (option == "4")
                {
                    Environment.Exit(0);     

                }
                else
                {
                    Console.WriteLine("Wrong input entered try again");
                }

            }
          
        }

        public static void DisplayMenu()
        {
            // creating a menu
            Console.WriteLine("Hello ! Please pick an option");
            Console.WriteLine("1: Display all lines");
            Console.WriteLine("2: Search by domain");
            Console.WriteLine("3: Calculate average age");
            Console.WriteLine("4: Exit");


        }
    }
}
