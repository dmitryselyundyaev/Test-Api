﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdApi.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Platform { get; set; }
        public string Commandline { get; set; }

    }
}