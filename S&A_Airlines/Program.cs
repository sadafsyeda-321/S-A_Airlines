using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("------ S & A AIRLINES MANAGEMENT SYSTEM ------");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("1: Login as Admin ");
            Console.WriteLine("2: Login as Passenger ");
            Console.WriteLine("3: Exit ");
            Console.WriteLine("Select your role: ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                AdminMenu();
            }
            else if (choice == "2")
            {
                PassengerMenu();
            }
            else
            {
                Console.WriteLine("Exiting the system! ");
            }
        }

        static void AdminMenu() 
        {
            while (true)
            {
                Console.WriteLine("----- ADMIN MENU -----");
                Console.WriteLine("1: Show All Passengers");
                Console.WriteLine("2: Search Passengers");
                Console.WriteLine("3: Update Passengers");
                Console.WriteLine("4: Delete Passengers");
                Console.WriteLine("5: View Purchase Menu");
                Console.WriteLine("6: View Available Flights with Seats");
                Console.WriteLine("7: View Tickets Price");
                Console.WriteLine("8: Exit the Menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    //Show All Passengers();
                }
            }

            
        }

        static void PassengerMenu()
        {

        }
    }
}
