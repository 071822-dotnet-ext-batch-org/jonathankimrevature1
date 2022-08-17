using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        
        public string Status = "Pending";

        public Ticket(decimal Amount, string Description)
        {
            this.Amount = Amount;
            this.Description = Description;
        }

        public void Approve()
        {
            this.Status = "Approved";
        }
     
        public void Deny()
        {
            this.Status = "Denied";
        }

    }
}
