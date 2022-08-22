using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class UpdatedTicketDTO
    {
        public UpdatedTicketDTO(Guid ticketID, string firstName, string lastName, int status)
        {
            TicketID = ticketID;
            FirstName = firstName;
            LastName = lastName;
            Status = status;

        }

        public Guid TicketID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }

    }
}
