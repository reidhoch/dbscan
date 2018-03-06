﻿namespace DbScan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MathNet.Numerics.LinearAlgebra;

    public sealed class Cluster<T> : IEquatable<Cluster<T>>
    where T : struct, IEquatable<T>, IFormattable
    {
        private readonly IList<Vector<T>> points;

        public Cluster() => this.points = new List<Vector<T>>();

        public IList<Vector<T>> Points
        {
            get
            {
                return this.points;
            }
        }

        public override int GetHashCode() => this.points.GetHashCode();

        public override bool Equals(object obj) => this.Equals(obj as Cluster<T>);

        public bool Equals(Cluster<T> other)
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