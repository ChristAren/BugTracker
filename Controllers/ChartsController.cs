﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models.ChartModels;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class ChartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private List<string> _backgroundColors;

        public ChartsController(ApplicationDbContext context)
        {
            _context = context;
            _backgroundColors = new List<string>
            {
                "#FF0000",
                "#19FF5A",
                "#FFCE19",
                "#0D22FF",
                "#FE7B00",
                "#19D0FF",
                "#D20DFF",
                "#A0FF19",
                "#00FF06",
                "#000000"
            };

        }

        public JsonResult PriorityChart()
        {
            var result = new ChartJsModel();
            var priorities = _context.TicketPriorities.ToList();
            int count = 0;
            foreach(var priority in priorities)
            {
                result.Labels.Add(priority.Name);
                result.Data.Add(_context.Tickets.Where(t => t.TicketPriorityId == priority.Id).Count());
                if(count < 10)
                {
                result.BackgroundColors.Add(_backgroundColors[count]);
                }
                else
                {
                    result.BackgroundColors.Add(_backgroundColors[count % 10]);
                }
                count++;
            }
            return Json(result);
        }

    }
}
