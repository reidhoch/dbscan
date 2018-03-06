namespace DbScan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbScan.Distance;
    using MathNet.Numerics.LinearAlgebra;

    public class DBScanClusterer<T> : Clusterer<T>
    where T : struct, IEquatable<T>, IFormattable
    {
        public DBScanClusterer(double epsilon, int minPts)
            : this(epsilon, minPts, new EuclideanDistance<T>())
        {
        }

        public DBScanClusterer(double epsilon, int minPts, IDistanceMeasure<T> measure)
            : base(measure)
        {
            if (epsilon < 0.0d)
            {
                throw new ArgumentOutOfRangeException("epsilon", epsilon, "Argument must be greather than 0.0");
            }

            if (minPts < 0)
            {
                throw new ArgumentOutOfRangeException("minPts", minPts, "Argument must be greather than 0.0");
            }

            this.Epsilon = epsilon;
            this.MinPts = minPts;
        }

        private enum PointStatus
        {
            Noise,
            PartOfCluster,
        }

        public double Epsilon { get; private set; }

        public int MinPts { get; private set; }

        public override IEnumerable<Cluster<T>> Cluster(IEnumerable<Vector<T>> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }

            var clusters = new List<Cluster<T>>();
            var visited = new Dictionary<Vector<T>, PointStatus>();

            foreach (var point in points)
            {
                if (visited.ContainsKey(point))
                {
                    continue;
                }

                var neighbors = this.GetNeighbors(point, points);
                if (neighbors.Count >= this.MinPts)
                {
                    var cluster = new Cluster<T>();
                    clusters.Add(this.ExpandCluster(cluster, point, neighbors, points, visited));
                }
                else
                {
                    visited[point] = PointStatus.Noise;
                }
            }

            return clusters;
        }

        private Cluster<T> ExpandCluster(
            Cluster<T> cluster,
            Vector<T> point,
            IList<Vector<T>> neighbors,
            IEnumerable<Vector<T>> points,
            IDictionary<Vector<T>, PointStatus> visited)
        {
            cluster.Points.Add(point);
            visited[point] = PointStatus.PartOfCluster;

            IList<Vector<T>> seeds = new List<Vector<T>>(neighbors);
            var index = 0;
            while (index < seeds.Count)
            {
                var current = seeds[index];
                var status = PointStatus.Noise;

                if (!visited.ContainsKey(current))
                {
                    var currentNeghbors = this.GetNeighbors(current, points);
                    if (currentNeghbors.Count >= this.MinPts)
                    {
                        seeds = this.Merge(seeds, currentNeghbors);
                    }
                }

                if (status != PointStatus.PartOfCluster)
                {
                    visited[current] = PointStatus.PartOfCluster;
                    cluster.Points.Add(current);
                }

                index++;
            }

            return cluster;
        }

        private IList<Vector<T>> GetNeighbors(Vector<T> point, IEnumerable<Vector<T>> points)
        {
            var neighbors = new List<Vector<T>>();
            foreach (var neighbor in points)
            {
                if (point.Equals(neighbor))
                {
                    continue;
                }

                if (this.Distance(point, neighbor) <= this.Epsilon)
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }

        private IList<Vector<T>> Merge(IList<Vector<T>> one, IList<Vector<T>> two)
        {
            var setOne = new HashSet<Vector<T>>(one);
            var setTwo = new HashSet<Vector<T>>(two);

            setOne.UnionWith(setTwo);
            return new List<Vector<T>>(setOne);
        }
    }
}
