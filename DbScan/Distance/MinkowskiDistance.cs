namespace DbScan.Distance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbScan.Distance;
    using MathNet.Numerics;
    using MathNet.Numerics.LinearAlgebra;

    public class MinkowskiDistance<T> : IDistanceMeasure<T>
    where T : struct, IEquatable<T>, IFormattable
    {
        private readonly double p;

        public MinkowskiDistance()
            : this(2.0d)
        {
        }

        public MinkowskiDistance(double p)
        {
            this.p = p;
        }

        public double P
        {
            get { return this.p; }
        }

        public double Compute(Vector<T> a, Vector<T> b)
        {
            return Distance.Minkowski(this.p, a, b);
        }
    }
}