using System;
using System.Collections.Generic;
using System.Linq;

namespace DbScan
{
    public sealed class Cluster<T> : IEquatable<Cluster<T>> where T : IClusterable
    {
        private readonly IList<T> points;
        public IList<T> Points { get { return this.points; } }

        public Cluster()
        {
            this.points = new List<T>();
        }

        public override int GetHashCode() => this.points.GetHashCode();

        public override bool Equals(object obj) => Equals(obj as DoublePoint);

        public bool Equals(Cluster<T> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Enumerable.SequenceEqual(this.points, other.points);
        }
    }
}