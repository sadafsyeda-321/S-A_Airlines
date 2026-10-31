using S_A_Airlines.ModelLayer;
using S_A_Airlines.RepositoryLayer;
using S_A_Airlines.UILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.ServiceLayer
{
    internal class AdminService
    {
        private readonly AdminRepository _repository;
 
    public AdminService()
        {
            _repository = new AdminRepository();
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

        public Passenger UpdatePassengers(string name)
        {
            List<Passenger>passengers = _repository.GetAll();

            int foundPassenger = -1;
            for (int i = 0; i < passengers.Count;i++)
            {
                if (passengers[i].Name == name)
                {
                   foundPassenger = i;
                   break;
                }
            }
            if (foundPassenger != -1)
            {
                Passenger passenger = passengers[foundPassenger];

                // Old Records
                Console.WriteLine("---------- Old Record ---------\n");
                Console.WriteLine("Name\tCNIC No.\tTotal Tickets\tPremium\tBusiness Class\tExecutive\tEconomy\tOrigin Flight\tDestination Flight\tContact");
                Console.WriteLine(passengers[foundPassenger].Name + "\t"+
                    passengers[foundPassenger].CNIC + "\t" +
                    passengers[foundPassenger].Tickets + "\t" +
                    passengers[foundPassenger].Premium + "\t" +
                    passengers[foundPassenger].Business + "\t" +
                    passengers[foundPassenger].Executive + "\t" +
                    passengers[foundPassenger].Economy + "\t" +
                    passengers[foundPassenger].OriginCountry + "\t" +
                    passengers[foundPassenger].DestinationCountry + "\t" +
                    passengers[foundPassenger].ContactInfo + "\t"
                    );
            }

            // logic 
            return null;
        }

        public bool ViewPassenger(string name)
        {
            // logic
            return true;
        }
        public Passenger PurchaseMenu(string tickets)
        {
            // logic 
            return null;
        }

        public void premiumAvailable()
        {

        }
        public void businessAvailable()
        {

        }

        public void executiveAvailable()
        {
        List<Passenger> passengers = new List<Passenger>();
        int tickets_sold = 0;
        int tickets_available = 0;
        for (int i = 0; i < passengers.Count; i++)
        {
                //tickets_sold = tickets_sold + Executive_array[i];
        }
        //tickets_available = ExecutiveSeats - tickets_sold;
        Console.WriteLine("Total Executive seats available: " + tickets_available );
        }
        void economyAvailable()
        {
            int tickets_sold = 0;
            int tickets_available = 0;
            List<Passenger> passengers = new List<Passenger>();
            for (int i = 0; i < passengers.Count; i++)
            {
                //tickets_sold = tickets_sold + Economy_array[i];
            }
            //tickets_available = Economy - tickets_sold;
            Console.WriteLine("Total Economy seats available: " + tickets_available);
        }
        public Passenger AvailableSeats(string slots)
        {
            // logic 
            return null;
        }

        public Passenger ShowTicketssPrice(string slots)
        {
            // logic 
            return null;
        }

        public void ClearAllPassengers()
        {
            _repository.ClearAll();
        }
    }
    }
