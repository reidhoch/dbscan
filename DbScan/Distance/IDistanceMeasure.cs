namespace DbScan.Distance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MathNet.Numerics;
    using MathNet.Numerics.LinearAlgebra;

    public interface IDistanceMeasure<T>
    where T : struct, IEquatable<T>, IFormattable
    {
        double Compute(Vector<T> a, Vector<T> b);
    }
}