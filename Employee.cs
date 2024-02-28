using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project11
{
     public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Employee(string name, string surname, string login, string password)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
        }

    }
}
