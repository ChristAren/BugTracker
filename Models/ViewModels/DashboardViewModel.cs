﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models.ViewModels
{
    public class DashboardViewModel
    {
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();



        //public int PerspectiveStatusNew { get; set; }
        //public int PerspectiveStatusOpen { get; set; }
        //public int PerspectiveStatusDev { get; set; }
        //public int PerspectiveStatusClosed { get; set; }
    }
}
