using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ModelLayer
{
    public class Passenger
    {
        public string Name;
        public string CNIC;
        public string ContactInfo;
        public int Tickets;
        public static List<Flight> flights = new List<Flight>();
        public static List<Tickets> tickets = new List<Tickets>();
        public Passenger() { }
        public Passenger(string name, string cnic, string contactInfo, int tickets)
        {
            Name = name;
            CNIC = cnic;
            ContactInfo = contactInfo;
            Tickets = tickets;
        }

        public override string ToString()
        {
            return $"{Name},{CNIC},{ContactInfo},{Tickets}";
        }
    }
}
