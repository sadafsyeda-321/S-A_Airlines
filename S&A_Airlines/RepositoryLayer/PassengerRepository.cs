using S_A_Airlines.ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.RepositoryLayer
{
    internal class PassengerRepository
    {
        private readonly string _filePath = "Passenger.txt";
        public void Save(Passenger passenger)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(passenger.ToString());
            }
        }
        public void SaveAll(List<Passenger> passengers)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                foreach (var passenger in passengers)
                {
                    writer.WriteLine(passenger.ToString());
                }
            }
        }
        public List<Passenger> GetAll()
        {
            List<Passenger> passengers = new List<Passenger>();
            if (File.Exists(_filePath))
            {
                using (StreamReader writer = new StreamReader(_filePath))
                {
                    string record;
                    while ((record = writer.ReadLine()) != null)
                    {
                        Passenger passenger = new Passenger();

                        passenger.Name = getField(record,1);
                        passenger.CNIC = getField(record, 2);
                        passenger.ContactInfo = getField(record, 3);
                        passenger.Tickets = getField(record, 4);
                        passengers.Add(passenger);
                    }
                }
            }
            return passengers;
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
