namespace DbScan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbScan.Distance;
    using MathNet.Numerics.LinearAlgebra;

    public abstract class Clusterer<T>
    where T : struct, IEquatable<T>, IFormattable
    {
        private readonly IDistanceMeasure<T> measure;

        protected Clusterer(IDistanceMeasure<T> measure)
        {
            if (measure == null)
            {
                throw new ArgumentNullException(nameof(measure));
            }

            this.measure = measure;
        }

        public IDistanceMeasure<T> DistanceMeasure
        {
            get
            {
                return this.measure;
            }
        }

        public abstract IEnumerable<Cluster<T>> Cluster(IEnumerable<Vector<T>> points);

        protected double Distance(Vector<T> a, Vector<T> b)
        {
            return this.DistanceMeasure.Compute(a, b);
        }
    }
}