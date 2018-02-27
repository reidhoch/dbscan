using System;
using System.Collections.Generic;
using System.Linq;
using DbScan.Distance;

namespace DbScan
{
    public abstract class Clusterer<T> where T : IClusterable
    {
        private readonly IDistanceMeasure measure;

        public IDistanceMeasure DistanceMeasure { get { return this.measure; } }

        protected Clusterer(IDistanceMeasure measure) { this.measure = measure; }
        public abstract IEnumerable<Cluster<T>> Cluster(IEnumerable<T> points);

        protected double Distance(IClusterable a, IClusterable b)
        {
            return this.measure.compute(a.GetPoints(), b.GetPoints());
        }
    }
}