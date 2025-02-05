using System;
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
            Simulator simulator = new Simulator(10000, 1460, new Covid201X("Covid201X", false, 0.5f, 0.3f));
            simulator.RunSimulation();
        }
    }
}