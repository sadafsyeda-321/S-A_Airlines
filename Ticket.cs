using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ModelLayer
{
    public class Tickets
    {
        public string FlightNum;
        public string CNIC;
        public double Price;
        public string SeatClass;
        public Tickets() { }
        public static List<Flight> flights = new List<Flight>();

        public Tickets( string flightNum, string cNIC, double price, string seatClass )
        {
            CNIC = cNIC;
            Price = price;
            SeatClass = seatClass;
        }
        public override string ToString()
        {
            return $"{CNIC},{Price},{SeatClass}";
        }
    }
}
