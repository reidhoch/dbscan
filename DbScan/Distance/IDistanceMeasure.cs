namespace DbScan.Distance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IDistanceMeasure
    {
        double Compute(double[] a, double[] b);
    }
}