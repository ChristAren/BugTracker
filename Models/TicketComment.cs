using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class TicketComment
    {
        //Keys
        public int Id { get; set; }

        public int TicketId { get; set; }

        public string UserId { get; set; }

        //Body
        public string Comment { get; set; }

        public DateTimeOffset Created { get; set; }

        //Navigation
        public virtual Ticket Ticket { get; set; }

        public virtual BTUser User { get; set; }

    }
}
