using OOP_Project.ModelLayer;
using OOP_Project.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ServiceLayer
{
    public class TicketService
    {
        private readonly TicketRepository _ticketRepo;
        private readonly PassengerService _passengerService;
        private readonly PriceRepository _priceRepo;
        private readonly FlightService _flightService;

        private readonly string[] seatClasses = { "Premium", "Business", "Executive", "Economy" };

        public TicketService()
        {
            _ticketRepo = new TicketRepository();
            _passengerService = new PassengerService();
            _priceRepo = new PriceRepository();
            _flightService = new FlightService();
        }

        public int CountSold(string flightNum, string seatClass)
        {
            int count = 0;
            List<Tickets> tickets = _ticketRepo.GetAll();
            foreach (Tickets t in tickets)
            {
                if (t.FlightNum == flightNum && t.SeatClass == seatClass)
                {
                    count++;
                }
            }
            return count;
        }

        public int GetAvailableSeats(string flightNum, string seatClass)
        {
            Flight flight = _flightService.FindFlight(flightNum);
            if (flight == null)
            {
                return 0;
            }
            return flight.GetSeats(seatClass) - CountSold(flightNum, seatClass);
        }

        public int[] GetAvailableSeatsByClass(string flightNum)
        {
            int[] result = new int[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = GetAvailableSeats(flightNum, seatClasses[i]);
            }
            return result;
        }

        public int[] GetTicketsSoldByClass()
        {
            int[] result = new int[4];
            List<Tickets> tickets = _ticketRepo.GetAll();
            foreach (Tickets t in tickets)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (t.SeatClass == seatClasses[i])
                    {
                        result[i]++;
                    }
                }
            }
            return result;
        }

        public string BookTicket(string cnic, string flightNum, string seatClass)
        {
            if (_passengerService.PassengerExists(cnic) == false)
            {
                return "Passenger not found. Register first.";
            }
            if (_flightService.FindFlight(flightNum) == null)
            {
                return "Flight not found.";
            }
            int classIndex = GetClassIndex(seatClass);
            if (classIndex == -1)
            {
                return "Invalid seat class.";
            }
            if (GetAvailableSeats(flightNum, seatClass) <= 0)
            {
                return "No seats left in " + seatClass + ".";
            }

            List<Tickets> all = _ticketRepo.GetAll();
            double price = _priceRepo.GetAll()[classIndex];

            Tickets ticket = new Tickets(flightNum, cnic, price, seatClass);
            _ticketRepo.Save(ticket);

            return "Booked! Ticket " + ", Seat " + ", Price " + price;
        }

        public List<Tickets> GetTicketsByCnic(string cnic)
        {
            List<Tickets> mine = new List<Tickets>();
            List<Tickets> all = _ticketRepo.GetAll();
            foreach (Tickets t in all)
            {
                if (t.CNIC == cnic)
                {
                    mine.Add(t);
                }
            }
            return mine;
        }

        public List<Tickets> GetAllTickets()
        {
            return _ticketRepo.GetAll();
        }

        public bool CancelTicket(string ticketNum, string cnic)
        {
            List<Tickets> all = _ticketRepo.GetAll();
            for (int i = 0; i < all.Count; i++)
            {
                if (all[i].CNIC == cnic)
                {
                    all.RemoveAt(i);
                    _ticketRepo.SaveAll(all);
                    return true;
                }
            }
            return false;
        }
        public void DeleteTicketsByCnic(string cnic)
        {
            List<Tickets> all = _ticketRepo.GetAll();
            for (int i = all.Count - 1; i >= 0; i--)
            {
                if (all[i].CNIC == cnic)
                {
                    all.RemoveAt(i);
                }
            }
            _ticketRepo.SaveAll(all);
        }

        public void ClearAllTickets()
        {
            _ticketRepo.ClearAll();
        }

        public double[] GetPrices()
        {
            return _priceRepo.GetAll();
        }

        public bool UpdatePrice(string seatClass, double newPrice)
        {
            int classIndex = GetClassIndex(seatClass);
            if (classIndex == -1 || newPrice <= 0)
            {
                return false;
            }
            double[] prices = _priceRepo.GetAll();
            prices[classIndex] = newPrice;
            _priceRepo.SaveAll(prices);
            return true;
        }


        private int GetClassIndex(string seatClass)
        {
            for (int i = 0; i < seatClasses.Length; i++)
            {
                if (seatClasses[i] == seatClass)
                {
                    return i;
                }
            }
            return -1;
        }


      

    }
}
