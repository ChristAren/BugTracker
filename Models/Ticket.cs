﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Ticket
    {         
        //Overloaded Constructor (ctor)
        public Ticket()
        {
            Comments = new HashSet<TicketComment>();

            Attachments = new HashSet<TicketAttachment>();

            Notifications = new HashSet<Notification>();

            Histories = new HashSet<TicketHistory>();
        }

        //Keys

        //primary key
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int TicketTypeId { get; set; }

        public int TicketPriorityId { get; set; }

        public int TicketStatusId { get; set; }

        public string OwnerUserId { get; set; }

        public string DeveloperUserId { get; set; }

        //Body
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset Created { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset? Updated { get; set; }

        //Navigation

        public virtual Project Project { get; set; }

        public virtual TicketType TicketType { get; set; }

        public virtual TicketPriority TicketPriority { get; set; }

        public virtual TicketStatus TicketStatus { get; set; }

        public virtual BTUser OwnerUser { get; set; }

        public virtual BTUser DeveloperUser { get; set; }

        public virtual ICollection<TicketComment> Comments { get; set; }

        public virtual ICollection<TicketAttachment> Attachments { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<TicketHistory> Histories { get; set; }


    }
}
