using OOP_Project.ModelLayer;
using OOP_Project.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.UILayer
{
    public class AdminUI
    {
        private readonly AdminService _adminService;
        private readonly FlightService _flightService;
        private readonly PassengerService _passengerService;
        private readonly Common _common;

        public AdminUI()
        {
            _adminService = new AdminService();
            _passengerService = new PassengerService();
            _common = new Common();
            _flightService = new FlightService();
        }
        public void ShowAdminMenu()
        {
            Console.WriteLine();
            Console.Write("Admin username: ");
            string username = Console.ReadLine();
            Console.Write("Admin password: ");
            string password = Console.ReadLine();
            bool result = _adminService.IsValid(username, password);
            if (result == false)
            {
                Console.WriteLine("Wrong username or password.");
                Console.ReadKey();
            }
            else
            {
                string adminOption = "";
                while (adminOption != "0")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("-------   Admin Menu    -------");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("1. Show all passengers");
                    Console.WriteLine("2. Search Passengers");
                    Console.WriteLine("3. View Passenger Tickets");
                    Console.WriteLine("4. Update Passenger Record");
                    Console.WriteLine("5. Delete Record by Name");
                    Console.WriteLine("6. Filter By Name");
                    Console.WriteLine("7. Available Slots");
                    Console.WriteLine("8. View Ticket Price");
                    Console.WriteLine("9. Update Price");
                    Console.WriteLine("10. Purchase Menu");
                    Console.WriteLine("11. Add Flights");
                    Console.WriteLine("12. Print Flights");
                    Console.WriteLine("13. Print Tickets");
                    Console.WriteLine("14. Delete All Data");
                    Console.WriteLine("15. Page");
                    Console.WriteLine("16. Logout");
                    Console.WriteLine(" Choose the Option: ");
                    adminOption = Console.ReadLine();

                    if (adminOption == "1")
                    {
                        ViewAllPassengers();
                    }
                    else if (adminOption == "2")
                    {
                        SearchPassenger();
                    }
                    else if (adminOption == "3")
                    {
                        ViewPassengerTickets();
                    }
                    else if (adminOption == "4")
                    {
                        UpdatePassenger();
                    }
                    else if (adminOption == "5")
                    {
                        DeletePassenger();
                    }
                    else if (adminOption == "6")
                    {
                        SortedList();
                    }
                    else if (adminOption == "7")
                    {
                        CheckSeats();
                    }
                    else if (adminOption == "8")
                    {
                        ViewPrices();
                    }
                    else if (adminOption == "9")
                    {
                        UpdatePrice();
                    }
                    else if (adminOption == "10")
                    {
                        PurchaseMenu();
                    }
                    else if (adminOption == "11")
                    {
                        AddFlight();
                    }
                    else if (adminOption == "12")
                    {
                        _common.PrintFlights(_flightService.GetAllFlights());
                    }
                    else if (adminOption == "13") 
                    { 
                        Common.PrintTickets(_adminService.GetAllTickets());
                    }
                    else if (adminOption == "14") 
                    { 
                        ClearAll(); 
                    }
                    else if (adminOption == "15")
                    {
                        Page();
                    }
                    else if (adminOption == "16")
                    {
                        Console.WriteLine("Exiting the menu");
                        break;
                    }
                    else
                    { Console.WriteLine("Invalid choice."); }
                    Console.ReadKey();
                }
            }
        }
        private void ViewAllPassengers()
        {
            Console.Clear();
            Common.PrintPassengers(_passengerService.GetAllPassengers());
        }
        private void SearchPassenger()
        {
            Console.Clear();
            string name = Common.ReadText("Enter name to search: ");
            Passenger p = _passengerService.FindPassengersByName(name);

            if (p == null)
            {
                Console.WriteLine("Passenger not found.");
            }
            else
            {
                Console.WriteLine("Name: " + p.Name + " | CNIC: " + p.CNIC + " | Contact: " + p.ContactInfo);
            }
        }
        private void ViewPassengerTickets()
        {
            Console.Clear();
            string name = Common.ReadText("Enter passenger name: ");
            List<Tickets> tickets = _adminService.ViewPassenger(name);

            if (tickets == null)
            {
                Console.WriteLine("Passenger not found.");
            }
            else
            {
                Common.PrintTickets(tickets);
            }
        }
        private void UpdatePassenger()
        {
            Console.Clear();
            string name = Common.ReadText("Enter name of passenger to update: ");

            Console.Write("New name: ");
            string newName = Console.ReadLine().Trim();
            Console.WriteLine("Enter ID:");
            string newCnic = Console.ReadLine().Trim();
            Console.Write("New contact: ");
            string newContact = Console.ReadLine().Trim();
            _adminService.UpdatePassengers(name);
            Console.WriteLine("Passenger updated.");
        }
        private void DeletePassenger()
        {
            Console.Clear();
            string name = Common.ReadText("Enter name of passenger to delete: ");
            bool deleted = _passengerService.DeletePassengerByName(name);

            if (deleted == true)
            {
                Console.WriteLine("Passenger and their tickets deleted.");
            }
            else
            {
                Console.WriteLine("Passenger not found.");
            }
        }
        private void SortedList()
        {
            Console.Clear();
            Console.WriteLine("1. A to Z");
            Console.WriteLine("2. Z to A");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Common.PrintPassengers(_passengerService.GetPassengersSorted(true));
            }
            else if (choice == "2")
            {
                Common.PrintPassengers(_passengerService.GetPassengersSorted(false));
            }
            else
            {
                Console.WriteLine("Invalid Option!");
            }
        }
        private void CheckSeats()
        {
            Console.Clear();
            List<Flight> flights = _flightService.GetAllFlights();
            _common.PrintFlights(flights);
            string flightNum = Common.ReadText("Enter flight number: ");

            if (_flightService.FindFlight(flightNum) == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }
            int[] seats = _adminService.AvailableSeats(flightNum);
            Console.WriteLine("Available seats on " + flightNum + ":");
            Console.WriteLine("Premium:   " + seats[0]);
            Console.WriteLine("Business:  " + seats[1]);
            Console.WriteLine("Executive: " + seats[2]);
            Console.WriteLine("Economy:   " + seats[3]);
        }
        private void ViewPrices()
        {
            Console.Clear();
            double[] prices = _adminService.ShowTicketsPrice();
            Console.WriteLine("Premium:   " + prices[0]);
            Console.WriteLine("Business:  " + prices[1]);
            Console.WriteLine("Executive: " + prices[2]);
            Console.WriteLine("Economy:   " + prices[3]);
        }
        private void UpdatePrice()
        {
            Console.Clear();
            string seatClass = Common.ChooseSeatClass();
            if (seatClass == "")
            {
                return;
            }
            Console.Write("Enter new price: ");
            string text = Console.ReadLine();
            double newPrice = double.Parse(text);
            bool updated = _adminService.UpdateTicketPrice(seatClass, newPrice);

            if (updated == true)
            {
                Console.WriteLine("Price updated. It applies to future bookings only.");
            }
            else
            {
                Console.WriteLine("Price must be greater than 0.");
            }
        }
        private void PurchaseMenu()
        {
            Console.Clear();
            int[] sold = _adminService.PurchaseMenu();
            List<Flight> flights = new List<Flight>();
            Flight flight = new Flight();
            int total = - sold[0] + sold[1] + sold[2] + sold[3];
            Console.WriteLine("Tickets sold:");
            Console.WriteLine("Premium:   " + sold[0]);
            Console.WriteLine("Business:  " + sold[1]);
            Console.WriteLine("Executive: " + sold[2]);
            Console.WriteLine("Economy:   " + sold[3]);
            Console.WriteLine("Total:     " + total);
        }
        private void AddFlight()
        {
            Console.Clear();
            string flightNum = Common.ReadText("Flight number: ");
            string origin = Common.ReadText("Origin city: ");
            string destination = Common.ReadText("Destination city: ");
            Console.Write("Premium seats: ");
            int premium = int.Parse(Console.ReadLine());
            Console.Write("Business seats: ");
            int business = int.Parse(Console.ReadLine());
            Console.Write("Executive seats: ");
            int executive = int.Parse(Console.ReadLine());
            Console.Write("Economy seats: ");
            int economy = int.Parse(Console.ReadLine());
            Console.Write("Ticket: ");
            int ticket = int.Parse(Console.ReadLine());
            Flight flight = new Flight(flightNum, origin, destination,
                                       premium, business, executive, economy,ticket);
            bool added = _flightService.AddFlight(flight);
            if (added)
            {
                Console.WriteLine("Flight added.");
            }
            else
            {
                Console.WriteLine("This flight number already exists.");
            }
        }
        private string Page()
        {
            string value = Console.ReadLine();
            List<Passenger> passengers = new List<Passenger>();
            string choice = Console.ReadLine();
            if (choice == "F")
            {
                foreach (Passenger passenger in passengers)
                {
                    for (int i = 0; i < passenger.Name[5]; i++)
                    {
                        Console.WriteLine(passenger.Name[i]);
                        Console.WriteLine("First Page");
                    }
                }
                Console.ReadKey();
            }
            else if (choice == "L")
            {
                foreach (Passenger passenger in passengers)
                {
                    for (int i = 0; i < passenger.Name[10]; i++)
                    {
                        Console.WriteLine("Last Page");
                    }
                }
            }
            else
            {
                Console.WriteLine("Exit");
                }
                return value;
            }
        private void ClearAll()
        {
            Console.Write("Deletes all passengers and tickets. Type yes to confirm: ");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                _adminService.ClearAllPassengers();
                Console.WriteLine("Everything cleared.");
            }
            else
            {
                Console.WriteLine("Cancelled.");
            }
        }
    }
}
