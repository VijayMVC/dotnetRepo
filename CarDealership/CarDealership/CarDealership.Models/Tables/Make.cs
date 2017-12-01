﻿using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Make
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }

    }
}
