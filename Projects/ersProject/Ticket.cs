using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ersProject
{
    public class Ticket
    {
        public string employeeName { get; set; }

        public int amount { get; set; }

        public string description { get; set;}

        public int ticketNumber { get; }

        public static int ticketNumberSeed = 0;

        //public List<Tickets> allTickets = new List<Tickets>(); 

        public Ticket(string employeeName, int amount, string description)
        {
            this.employeeName = employeeName;
            this.amount = amount;
            this.description = description;
            this.ticketNumber = ticketNumberSeed + 1;
        }


        
    }
}