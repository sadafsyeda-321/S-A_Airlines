using OOP_Project.ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.RepositoryLayer
{
    public class PassengerRepository
    {
        private readonly string _filePath = "D:\\2nd Semester\\OOP\\OOP Project\\OOP Project\\RepositoryLayer\\Passenger.txt";
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
            Passenger passenger = new Passenger();
            StreamReader writer = new StreamReader(_filePath);
            string record;
            while ((record = writer.ReadLine()) != null)
            {
                passenger.Name = getField(record, 1).Trim();
                passenger.CNIC = getField(record, 2).Trim();
                passenger.ContactInfo = getField(record, 3).Trim();
                passenger.Tickets = int.Parse(getField(record, 4).Trim());
                passengers.Add(new Passenger(passenger.Name, passenger.CNIC, passenger.ContactInfo, passenger.Tickets));
            }
            writer.Close();
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
