using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.ModelLayer
{
    internal class Flight
    {
        public string FlightNum;
        public string OriginCountry;
           // Lahore" , "Medina", "Istanbul", "Cappadoccio", "Monaco", "Berlin", "London", "Paris", "Sydney", "Vienna"

        public string DestinationCountry;
        // "Vienna", "Sydney", "Berlin", "London", "Paris", "Monaco", "Cappadoccio", "Istanbul", "Medina", "Lahore" 

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
    }
}
