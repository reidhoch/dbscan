﻿namespace DbScan.Distance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbScan.Distance;
    using MathNet.Numerics;
    using MathNet.Numerics.LinearAlgebra;

    public class ChebyshevDistance<T> : IDistanceMeasure<T>
    where T : struct, IEquatable<T>, IFormattable
    {
        public double Compute(Vector<T> a, Vector<T> b)
        {
            return Distance.Chebyshev(a, b);
        }
    }
}