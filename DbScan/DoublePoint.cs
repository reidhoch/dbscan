using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DbScan
{
    [DebuggerDisplay("{points[0]}, {points[1]}")]
    public class DoublePoint : IClusterable
    {
        private readonly double[] points;

        public DoublePoint(double[] points) => this.points = points;
        public double[] GetPoints() => this.points;

        public override int GetHashCode() => this.points.GetHashCode();

        public override bool Equals(object obj)
        {
            var other = obj as DoublePoint;
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Enumerable.SequenceEqual(this.points, other.points);
        }
    }
}