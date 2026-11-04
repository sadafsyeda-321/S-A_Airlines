using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.UILayer;

namespace OOP_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            AdminUI adminUI = new AdminUI();
            PassengerUI passengerUI = new PassengerUI();

            string choice = "";
            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("------ S & A AIRLINES MANAGEMENT SYSTEM ------");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Passenger");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    adminUI.ShowAdminMenu();
                }
                else if (choice == "2")
                {
                    passengerUI.ShowPassengerMenu();
                }
                else if (choice != "0")
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

            Console.WriteLine("Exiting the system!");
        }
    }
}
