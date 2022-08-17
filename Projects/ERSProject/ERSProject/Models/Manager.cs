using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Manager
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } = "Manager";
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Manager(string Username, string Password, string FirstName, string LastName)
        {
            this.Username = Username;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

       
        //why is approve/deny tickets in Manager class but submit ticket is not in the employee class? Why not in the ticket class?
        //Because Approve and Deny have to do with the state of Ticket. The manager changes the state of ticket.
        //For things like, how Ticket is used outside of the class library is different. 

        //insert approving/denying tickets code here



    }

}
