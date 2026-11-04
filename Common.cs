using OOP_Project.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.UILayer
{
    public class Common
    {
        public static string ReadText(string message)
        {
            string text = "";
            while (text == "")
            {
                Console.Write(message);
                text = Console.ReadLine().Trim();
                if (text == "")
                {
                    Console.WriteLine("This cannot be empty.");
                }
                else if (text.Contains(","))
                {
                    Console.WriteLine("Commas are not allowed.");
                    text = "";
                }
            }
            return text;
        }

        public static string ChooseSeatClass()
        {
            Console.Clear();
            Console.WriteLine("1. Premium");
            Console.WriteLine("2. Business");
            Console.WriteLine("3. Executive");
            Console.WriteLine("4. Economy");
            Console.Write("Choose class (1-4): ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                return "Premium";
            }
            else if (choice == "2")
            {
                return "Business";
            }
            if (choice == "3")
            {
                return "Executive";
            }
            else if (choice == "4")
            {
                return "Economy";
            }
            else
            {
                Console.WriteLine("Invalid class.");
            }
            return "";
        }

        public static void PrintTickets(List<Tickets> tickets)
        {
            List<Passenger> passengers = new List<Passenger>();
            Console.Clear();
            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets found.");
                Console.ReadKey();
            }
            foreach (Tickets t in tickets)
            {
                Console.WriteLine("Ticket: " +
                                  " | Flight: " + t.FlightNum +
                                  " | Class: " + t.SeatClass +
                                  " | Price: " + t.Price +
                                  " | CNIC: " + t.CNIC);
                Console.ReadKey();
            }
        }
        public void PrintFlights(List<Flight> flights)
        {
            Console.Clear();
            if (flights.Count == 0)
            {
                Console.WriteLine("No flights available.");
            }
            else
            { 
            foreach (Flight f in flights)
            {
                Console.WriteLine(f.FlightNum + " | " + f.OriginCountry + " - " + f.DestinationCountry +
                                  " | Premium: " + f.PremiumSeats +
                                  " | Business: " + f.BusinessSeats +
                                  " | Executive: " + f.ExecutiveSeats +
                                  " | Economy: " + f.EconomySeats);
            }
          }
            Console.ReadKey();
        }
        public static void PrintPassengers(List<Passenger> passengers)
        {
            Console.Clear();
            if (passengers.Count == 0)
            {
                Console.WriteLine("No passengers found.");
            }
            foreach (Passenger p in passengers)
            {
                Console.WriteLine("Name: " + p.Name + " | CNIC: " + p.CNIC + " | Contact: " + p.ContactInfo + " | Tickets: " + p.Tickets);
            }
        }
    }
}
