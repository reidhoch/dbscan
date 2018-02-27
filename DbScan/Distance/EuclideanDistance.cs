using System;
using System.Collections.Generic;
using System.Linq;
using DbScan.Distance;

namespace DbScan.Distance
{
    public class EuclideanDistance : IDistanceMeasure
    {
        public double compute(double[] a, double[] b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException("Dimension mismatch", "a");

            var result = 0.0d;
            for (var i = 0; i < a.Length; i++)
            {
                result += Math.Abs(a[i] - b[i]);
            }
            return result;
        }
    }
}