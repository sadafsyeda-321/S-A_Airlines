using OOP_Project.ModelLayer;
using OOP_Project.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ServiceLayer
{
    public class PassengerService
    {
        private readonly PassengerRepository _repository;
        public PassengerService()
        {
            _repository = new PassengerRepository();
        }

        public List<Passenger> GetAllPassengers()
        {
            return _repository.GetAll();
        }
        public bool AddPassenger(Passenger passenger)
        {
            if (FindPassengersByCnic(passenger.CNIC) != null)
            {
                return false;
            }
            _repository.Save(passenger);
            return true;
        }

        public Passenger FindPassengersByCnic(string cnic)
        {
            List<Passenger> passengers = _repository.GetAll();
            /*List<Passenger> passengers = new List<Passenger>();
            passengers = _repository.GetAll();*/
            foreach (Passenger passenger in passengers)
            {
                if (passenger.CNIC == cnic)
                {
                    return passenger;
                }
            }
            return null;
        }
        public Passenger FindPassengersByName(string name)
        {
            List<Passenger> passengers = _repository.GetAll();
            /*List<Passenger> passengers = new List<Passenger>();
            passengers = _repository.GetAll();*/
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == name)
                {
                    return passenger;
                }
            }
            return null;
        }
        public bool DeletePassengerByName(string name)
        {
            List<Passenger> passengers = _repository.GetAll();
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Passenger> GetTicketsSortedByCnic(bool ascending)
        {
            List<Passenger> passengers = _repository.GetAll();

            List<Passenger> newList;

            if (ascending == true)
            {
                newList = passengers.OrderBy(o => o.CNIC).ToList();
            }
            else
            {
                newList = passengers.OrderByDescending(o => o.CNIC).ToList();
            }

            return newList;
        }
        public List<Passenger> GetPassengersSorted(bool ascending)
        {
            List<Passenger> passengers = _repository.GetAll();

            List<Passenger> newList;

            if (ascending == true)
            {
                newList = passengers.OrderBy(n => n.Name).ToList();
            }
            else
            {
                newList = passengers.OrderByDescending(n => n.Name).ToList();
            }

            return newList;
        }
        public bool UpdatePassengers(string name)
        {
            List<Passenger> passengers = _repository.GetAll();

            int foundPassenger = -1;
            for (int i = 0; i < passengers.Count; i++)
            {
                if (passengers[i].Name == name)
                {
                    foundPassenger = i;
                    break;
                }
            }
            if (foundPassenger != -1)
            {
                // Old Records
                Console.WriteLine("---------- Old Record ---------\n");
                Console.WriteLine("Name\tCNIC No.\t Tickets\tContact");
                Console.WriteLine(passengers[foundPassenger].Name + "\t" +
                    passengers[foundPassenger].CNIC + "\t" +
                    passengers[foundPassenger].ContactInfo + "\t" +
                    passengers[foundPassenger].Tickets + "\t"
                    );
            }
            return false;
        }

        public bool PassengerExists(string cnic)
        {
            List<Passenger> passengers = _repository.GetAll();
            foreach (Passenger p in passengers)
            {
                if (p.CNIC == cnic)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
