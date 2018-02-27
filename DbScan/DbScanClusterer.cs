﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DbScan
{
    public class DBScanClusterer<T> where T : IClusterable
    {
        private enum PointStatus
        {
            Noise,
            PartOfCluster
        }

        public double Epsilon { private set; get; }
        public int MinPts { private set; get; }

        public DBScanClusterer(double epsilon, int minPts)
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

        public IEnumerable<Cluster<T>> Cluster(IEnumerable<T> points)
        {
            if (null == points)
            {
                throw new ArgumentNullException("points");
            }
            var clusters = new List<Cluster<T>>();
            var visited = new Dictionary<IClusterable, PointStatus>();

            foreach (var point in points)
            {
                if (visited.ContainsKey(point))
                    continue;
                var neighbors = GetNeighbors(point, points);
                if (neighbors.Count >= MinPts)
                {
                    var cluster = new Cluster<T>();
                    clusters.Add(ExpandCluster(cluster, point, neighbors, points, visited));
                }
                else
                {
                    visited[point] = PointStatus.Noise;
                }

            }
            return clusters;
        }

        private Cluster<T> ExpandCluster(Cluster<T> cluster,
                                         T point,
                                         IList<T> neighbors,
                                         IEnumerable<T> points,
                                         Dictionary<IClusterable, PointStatus> visited)
        {
            cluster.Points.Add(point);
            visited[point] = PointStatus.PartOfCluster;

            IList<T> seeds = new List<T>(neighbors);
            var index = 0;
            while (index < seeds.Count)
            {
                var current = seeds[index];
                var status = PointStatus.Noise;

                if (!visited.ContainsKey(current))
                {
                    var currentNeghbors = GetNeighbors(current, points);
                    if (currentNeghbors.Count >= MinPts)
                    {
                        seeds = merge(seeds, currentNeghbors);
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

        private IList<T> GetNeighbors(T point, IEnumerable<T> points)
        {
            var neighbors = new List<T>();
            foreach (var neighbor in points)
            {
                if (point.Equals(neighbor))
                    continue;
                if (distance(point, neighbor) <= Epsilon)
                    neighbors.Add(neighbor);
            }
            return neighbors;
        }

        private double distance(T one, T two)
        {
            var p1 = one.GetPoints();
            var p2 = two.GetPoints();
            var dim = Math.Min(p1.Length, p2.Length);
            var result = 0.0d;
            for (var i = 0; i < dim; i++)
            {
                result += Math.Abs(p1[i] - p2[i]);
            }
            return result;
        }

        private IList<T> merge(IList<T> one, IList<T> two)
        {
            var setOne = new HashSet<T>(one);
            var setTwo = new HashSet<T>(two);

            setOne.UnionWith(setTwo);
            return new List<T>(setOne);
        }
    }
}
