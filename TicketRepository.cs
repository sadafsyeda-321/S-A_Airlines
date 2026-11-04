using OOP_Project.ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.RepositoryLayer
{
    public class TicketRepository
    {
        private readonly string _filePath = "D:\\2nd Semester\\OOP\\OOP Project\\OOP Project\\RepositoryLayer\\Ticket.txt";

        public void Save(Tickets ticket)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(ticket.ToString());
            }
        }

        public void SaveAll(List<Tickets> tickets)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                foreach (Tickets ticket in tickets)
                {
                    writer.WriteLine(ticket.ToString());
                }
            }
        }

        public List<Tickets> GetAll()
        {
            List<Tickets> tickets = new List<Tickets>();
            if(!File.Exists(_filePath))
            {
                return tickets; // Returns an empty list safely
            }
            using (StreamReader reader = new StreamReader(_filePath))
            { 
            string record;
            while ((record = reader.ReadLine()) != null)
            {
                    Tickets ticket = new Tickets();
                    ticket.FlightNum = getField(record, 1).Trim();
                    ticket.CNIC = getField(record, 2).Trim();
                    ticket.Price = double.Parse(getField(record, 3).Trim());
                    ticket.SeatClass = getField(record, 4).Trim();
                    tickets.Add(ticket);
            }
            }
            return tickets;
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

        public string getField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }


        public void ClearAll()
        {
            File.WriteAllText(_filePath, string.Empty);
        }
    }
}
