using OOP_Project.ModelLayer;
using OOP_Project.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.UILayer
{
    public class PassengerUI
    {
        private readonly PassengerService _passengerService;
        private readonly TicketService _ticketService;
        private readonly FlightService _flightService;
        private readonly Common _common;

        public PassengerUI()
        {
            _passengerService = new PassengerService();
            _ticketService = new TicketService();
            _flightService = new FlightService();
            _common = new Common();
        }
        public void ShowPassengerMenu()
        {
            string choice = "";
            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("===== PASSENGER =====");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login (with CNIC)");
                Console.WriteLine("0. Back");
                Console.Write("Enter choice: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Register();
                }
                else if (choice == "2")
                {
                    Login();
                }
                else if (choice != "0")
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }

        private void Register()
        {
            Console.Clear();
            Console.WriteLine();
            string name = Common.ReadText("Enter name: ");
            string cnic = Common.ReadText("Enter CNIC: ");
            string contact = Common.ReadText("Enter contact info: ");
            int tickets = int.Parse(Common.ReadText("Enter tickets:"));
            if (tickets > 1)
            {
                Console.WriteLine("Select a single seat");
            }
            else 
            {
                Console.WriteLine("Ticket Booked");
            }
            Passenger passenger = new Passenger(name, cnic, contact, tickets);
            _passengerService.AddPassenger(passenger);
            Console.WriteLine("Registered successfully!");
        }
        private void Login()
        {
            Console.Clear();
            Console.WriteLine();
            string cnic = Common.ReadText("Enter your CNIC: ");
            Passenger passenger = _passengerService.FindPassengersByCnic(cnic);
            if (passenger != null && passenger.CNIC == cnic)
            {
                LoggedInMenu(passenger);
            }
            else
            {
                Console.WriteLine("CNIC not found. Please register first.");
            }
            Console.ReadKey();
        }

        private void LoggedInMenu(Passenger passenger)
        {
            string choice = "";
            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("===== MY ACCOUNT =====");
                Console.WriteLine("1. View flights");
                Console.WriteLine("2. Book a ticket");
                Console.WriteLine("0. Logout");
                Console.Write("Enter choice: ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    _common.PrintFlights(_flightService.GetAllFlights());
                }
                else if (choice == "2")
                {
                    BookTicket(passenger);
                }
                else if(choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                }
            }
        }
        private void BookTicket(Passenger passenger)
        {
            Console.Clear();
            Console.WriteLine();
            _common.PrintFlights(_flightService.GetAllFlights());
            string flightNum = Common.ReadText("Enter flight number: ");
            int tickets = int.Parse(Common.ReadText("Enter flight number: "));
            double[] prices = _ticketService.GetPrices();
            Console.WriteLine("Prices of Tickets: \n Premium: " + prices[0] + ", Business: " + prices[1] +
                              ", Executive: " + prices[2] + ", Economy: " + prices[3]);
            string seatClass = Common.ChooseSeatClass();
            if (seatClass == "" && seatClass == null)
            {
                Console.WriteLine("Invalid");
            }
            else {
                string message = _ticketService.BookTicket(passenger.CNIC, flightNum, seatClass);
                Console.WriteLine(message);
            }
            Console.ReadKey();
        }

        private void CancelTicket(Passenger passenger)
        {
            Console.Clear();
            List<Tickets> mine = _ticketService.GetTicketsByCnic(passenger.CNIC);
            if (mine.Count == 0)
            {
                Console.WriteLine("No Ticket Found");
            }
            else
            {
                Common.PrintTickets(mine);
                string ticketNum = Common.ReadText("Enter ticket number to cancel: ");
                bool cancelled = _ticketService.CancelTicket(ticketNum, passenger.CNIC);
                if (cancelled == true)
                {
                    Console.WriteLine("Ticket cancelled.");
                }
                else
                {
                    Console.WriteLine("Ticket not found in your bookings.");
                }
            }
        }
    }
}
