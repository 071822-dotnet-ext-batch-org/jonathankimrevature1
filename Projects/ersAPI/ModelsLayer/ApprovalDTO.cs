using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ApprovalDTO
    {
        public Guid EmployeeId { get; set; }
        public Guid TicketID { get; set; }
        public int Status { get; set; }

    }
}
