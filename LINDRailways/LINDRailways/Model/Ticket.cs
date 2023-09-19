﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDRailways.Model
{
    public class Ticket
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public int IsMale { get; set; }
        public int IsPaid { get; set; }
        public string DepartureDate { get; set; }
        public string TrainName { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
    }
}