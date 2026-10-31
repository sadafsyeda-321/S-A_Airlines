using S_A_Airlines.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace S_A_Airlines.UILayer
{
    public class AdminUI
    {
        private readonly AdminService _adminService;
        public void ShowAdminMenu()
        {
            Console.Clear();
            Console.Write("Enter Username: ");
            string user = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (Username != user && password != password)
            {
                Console.WriteLine("-------   Admin Menu    -------\n");
                Console.WriteLine("1. Show all passengers \n");
                Console.WriteLine("2. Search Passengers \n");
                Console.WriteLine("3. Update Passenger Record \n");
                Console.WriteLine("4. Generate List \n");
                Console.WriteLine("5. Delete Record by Name \n");
                Console.WriteLine("6. Ticket Price \n");
                Console.WriteLine("7. Purchase Menu \n");
                Console.WriteLine("8. Available Slots \n");
                Console.WriteLine("9. Logout \n");
                Console.WriteLine(" Choose the Option: ");
                string adminOption = Console.ReadLine();
                return adminOption;
            }
        }
    }
}
