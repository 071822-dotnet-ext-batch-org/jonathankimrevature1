using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Ticket
    {
        public Ticket(Guid ticketID, Guid fK_Employee, string description, decimal amount, int status)
        {
            TicketID = ticketID;
            FK_Employee = fK_Employee;
            Description = description;
            Amount = amount;
            Status = status;
        }

        public Guid TicketID { get; set; }
        public Guid FK_Employee { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
    }
}
