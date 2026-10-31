using S_A_Airlines.ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.RepositoryLayer
{
    internal class FlightRepository
    {
        private readonly string _filePath = "Flight.txt";

        public void Save(Flight flights)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(flights.ToString());
            }
        }
        public void SaveAll(List<Flight> flights)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                foreach (var flight in flights)
                {
                    writer.WriteLine(flight.ToString());
                }
            }
        }
        public List<Flight> GetAll()
        {
            List<Flight> flights = new List<Flight>();
            if (File.Exists(_filePath))
            {
                using (StreamReader writer = new StreamReader(_filePath))
                {
                    string record;
                    while ((record = writer.ReadLine()) != null)
                    {
                        Flight flight = new Flight();

                        flight.FlightNum = getField(record, 1);
                        flight.OriginCountry = getField(record, 2);
                        flight.DestinationCountry = getField(record, 3);
                        flights.Add(flight);
                    }
                }
            }
            return flights;
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
