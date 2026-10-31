using S_A_Airlines.ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.RepositoryLayer
{
    internal class AdminRepository
    {
        private readonly string _filePath = "Admin.txt";

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
            //
            return passengers;
        }

        public void ClearAll()
        {
            File.WriteAllText(_filePath, string.Empty);
        }
    }
}
