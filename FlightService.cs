using OOP_Project.ModelLayer;
using OOP_Project.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ServiceLayer
{
    public class FlightService
    {
        private readonly FlightRepository _repository;

        public FlightService()
        {
            _repository = new FlightRepository();
        }

        public List<Flight> GetAllFlights()
        {
            return _repository.GetAll();
        }
        public Flight FindFlight(string flightNum)
        {
            List<Flight> flights = _repository.GetAll();
            foreach (Flight flight in flights)
            {
                if (flight.FlightNum == flightNum)
                {
                    return flight;
                }
            }
            return null;
        }

        public int GetSeats(string seatClass)
        {
            Flight flight = new Flight();
            if (seatClass == "Premium")
            {
                return flight.PremiumSeats;
            }
            else if (seatClass == "Business")
            {
                return flight.BusinessSeats;
            }
            else if (seatClass == "Executive")
            {
                return flight.ExecutiveSeats;
            }
            else if (seatClass == "Economy")
            {
                return flight.EconomySeats;
            }
            else
            {
                return 0;
            }
        }
        public int GetTotalSeats(List<Flight> flights)
        {
            Flight flight = new Flight();
            string flightNum = "";
            flight = FindFlight(flightNum);
            return flight.PremiumSeats + flight.BusinessSeats + flight.ExecutiveSeats + flight.EconomySeats;
        }
        public bool AddFlight(Flight flight)
        {
            if (FindFlight(flight.FlightNum) != null)
            {
                return false;
            }
            _repository.Save(flight);
            return true;
        }
    }
}
