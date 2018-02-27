using System;
using System.Collections.Generic;
using System.Linq;

namespace DbScan.Distance {
    public interface IDistanceMeasure {
        double compute(double[] a, double[] b);
    }
}