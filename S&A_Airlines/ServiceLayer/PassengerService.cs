using S_A_Airlines.ModelLayer;
using S_A_Airlines.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.ServiceLayer
{
    internal class PassengerService
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
        public void AddPassenger(Passenger passenger)
        {
            _repository.Save(passenger);
        }
        // Search through Name
        public Passenger FindPassengersByName(string name)
        {
            List<Passenger> passengers = new List<Passenger>();
            passengers = _repository.GetAll();
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == name)
                {
                    return passenger;
                }
            }
            return null;
        }
        // Delete by Name
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

        
        public void ClearAllPassengers()
        {
            _repository.ClearAll();
        }
    }
    }