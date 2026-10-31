using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.ModelLayer
{
    public class Tickets
    {
        public string TicketNum;
        public string FlightNum;
        public string CNIC;
        public string SeatNum;
        public double Price;
        public string SeatClass;
        public Tickets() { }

        public Tickets(string ticketNum, string flightNum, string cNIC, string seatNum, double price, string seatClass)
        {
            TicketNum = ticketNum;
            FlightNum = flightNum;
            CNIC = cNIC;
            SeatNum = seatNum;
            Price = price;
            SeatClass = seatClass;
        }
        public override string ToString()
        {
            return $"{TicketNum},{FlightNum},{CNIC},{SeatNum},{Price},{SeatClass}";
        }
    }
}
