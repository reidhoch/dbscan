namespace DbScan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbScan.Distance;

    public abstract class Clusterer<T>
    where T : IClusterable
    {
        private readonly IDistanceMeasure measure;

        protected Clusterer(IDistanceMeasure measure) => this.measure = measure;

        public IDistanceMeasure DistanceMeasure
        {
            get
            {
                return this.measure;
            }
        }

        public abstract IEnumerable<Cluster<T>> Cluster(IEnumerable<T> points);

        protected double Distance(IClusterable a, IClusterable b)
        {
            return this.DistanceMeasure.Compute(a.GetPoints(), b.GetPoints());
        }
    }
}