﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Simulator simulator = new Simulator(1000000, 3650);
            simulator.RunSimulation();
        }
    }
}