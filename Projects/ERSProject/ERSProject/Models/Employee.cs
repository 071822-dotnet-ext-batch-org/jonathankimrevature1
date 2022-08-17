using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } = "Employee";
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Employee U1 { get; set; } = new Employee();

        public Employee(string Username, string Password, string FirstName, string LastName)
        {
            this.Username = Username;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public Employee() {}
    }

           

}
