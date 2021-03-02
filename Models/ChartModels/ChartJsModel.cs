﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models.ChartModels
{
    public class ChartJsModel
    {
        public ChartJsModel()
            {
            Labels = new List<string>();
            Data = new List<int>();
            BackgroundColors = new List<string>();
            }
        //I need 2 collections of string and 1 collection of integers
        public List<string> Labels { get; set; }

        public List<int> Data { get; set; }

        public List<string> BackgroundColors { get; set; }


    }
}
