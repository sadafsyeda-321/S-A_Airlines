using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ModelLayer
{
    public class Flight
    {
        public string FlightNum;
        public string OriginCountry;
        public string DestinationCountry;
        public int Ticket;
        public int PremiumSeats;
        public int BusinessSeats;
        public int ExecutiveSeats;
        public int EconomySeats;
        public int TotalSeats;
        public Flight() { }
        public Flight(string flightNum, string origin, string destination)
        {
            FlightNum = flightNum;
            OriginCountry = origin;
            DestinationCountry = destination;
        }
        public Flight(string flightNum, string origin, string destination,
                      int premium, int business, int executive, int economy, int ticket)
        {
            FlightNum = flightNum;
            OriginCountry = origin;
            DestinationCountry = destination;
            PremiumSeats = premium;
            BusinessSeats = business;
            ExecutiveSeats = executive;
            EconomySeats = economy;
            Ticket = ticket;
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
        public override string ToString()
        {
            return $"{FlightNum},{OriginCountry},{DestinationCountry},{PremiumSeats},{BusinessSeats},{ExecutiveSeats},{EconomySeats}";
        }
    }
}
