namespace DbScan
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerDisplay("{points[0]}, {points[1]}")]
    public sealed class DoublePoint : IClusterable, IEquatable<DoublePoint>
    {
        private readonly double[] points;

        public DoublePoint(double[] points) => this.points = points;

        public double[] GetPoints() => this.points;

        public override int GetHashCode() => this.points.GetHashCode();

        public override bool Equals(object obj) => this.Equals(obj as DoublePoint);

        public bool Equals(DoublePoint other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Enumerable.SequenceEqual(this.points, other.points);
        }
    }
}