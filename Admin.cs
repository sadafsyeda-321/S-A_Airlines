using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.ModelLayer
{
    public class Admin
    {
        public string Username;
        public string Password;
        public Admin() { }
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
