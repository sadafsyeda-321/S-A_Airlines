using S_A_Airlines.ModelLayer;
using S_A_Airlines.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.UILayer
{
    public class PassengerUI
    {
        private readonly PassengerService _passengerService;
        public void ShowPassengerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------- Passenger Menu ----------");
                Console.WriteLine("1. View Flights");
                Console.WriteLine("1. Book a Seat");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine("Choose Option: ");

                string option = Console.ReadLine();
                if (option == "1")
                {

                }
                else if (option == "2")
                {

                }
                else if (option == "3")
                {
                    break;
                }
            }
        }

        private void ViewFlights()
        {
            Console.Clear() ;
            //var flight = _passengerService.GetAllFlights();
        }
    }
}
