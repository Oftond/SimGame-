﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Gaussian
{
    private static Random rand = new Random();

    public static double RandNormal(double mean, double stdDev)
    {
        double u1 = 1 - rand.NextDouble();
        double u2 = 1 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0  * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return mean + stdDev * randStdNormal;
    }
}