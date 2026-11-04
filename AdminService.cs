using OOP_Project.ModelLayer;
using OOP_Project.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ServiceLayer
{
    public class AdminService
    {
        private readonly AdminRepository _repository;
        private readonly PassengerService _passengerService;
        private readonly TicketService _ticketService;
        public List<Admin> adminlist;

        public AdminService()
        {
            _repository = new AdminRepository();
            _passengerService = new PassengerService();
            _ticketService = new TicketService();
            adminlist = _repository.GetAll();
        }
        public bool IsValid(string username, string password)
        {
            foreach (Admin a in adminlist)
            {
                if (a.Username == username && a.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Passenger> GetAllPassengers()
        {
            return _passengerService.GetAllPassengers();
        }
        public void AddPassenger(Passenger passenger)
        {
            _passengerService.AddPassenger(passenger);
        }
        public Passenger FindPassengersByName(string name)
        {
            return _passengerService.FindPassengersByCnic(name);
        }
        public List<Tickets> ViewPassenger(string name)
        {
            Passenger p = _passengerService.FindPassengersByName(name);
            if (p == null)
            {
                return null;
            }
            return _ticketService.GetTicketsByCnic(p.CNIC);
        }

        public void UpdatePassengers(string name)
        {
            _passengerService.UpdatePassengers(name);
        }

        public bool DeletePassengerByName(string name)
        {
            Passenger p = _passengerService.FindPassengersByName(name);
            if (p == null)
            {
                return false;
            }
            _ticketService.DeleteTicketsByCnic(p.CNIC);
            return _passengerService.DeletePassengerByName(name);
        }

        public List<Passenger> GetPassengersSorted(bool ascending)
        {
            return _passengerService.GetPassengersSorted(ascending);
        }

        public int[] AvailableSeats(string flightNum)
        {
            return _ticketService.GetAvailableSeatsByClass(flightNum);
        }
        public double[] ShowTicketsPrice()
        {
            return _ticketService.GetPrices();
        }
        public bool UpdateTicketPrice(string seatClass, double newPrice)
        {
            return _ticketService.UpdatePrice(seatClass, newPrice);
        }
        public int[] PurchaseMenu()
        {
            return _ticketService.GetTicketsSoldByClass();
        }
        public List<Tickets> GetAllTickets()
        {
            return _ticketService.GetAllTickets();
        }
        public List<Passenger> GetTicketsbyCnic(bool ascending)
        {
            return _passengerService.GetTicketsSortedByCnic(ascending);
        }
        public List<Admin> GetAll()
        {
            return _repository.GetAll();
        }
        public void Add(Admin admin)
        {
            _repository.Save(admin);
        }
        public void ClearAllPassengers()
        {
            _repository.ClearAll();
        }
    }
}
