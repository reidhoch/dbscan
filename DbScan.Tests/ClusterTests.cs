namespace DbScan.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbScan;
    using MathNet.Numerics.LinearAlgebra;
    using Xunit;

    public class ClusterTests
    {
        [Fact]
        public void NewClusterTest()
        {
            var cluster = new Cluster<double>();
            Assert.NotNull(cluster);
            Assert.NotNull(cluster.Points);

            // Cluster should be empty when initialized
            Assert.Empty(cluster.Points);
        }

        [Fact]
        public void ClustersAreEqualTest()
        {
            var cluster1 = new Cluster<double>();
            var cluster2 = new Cluster<double>();
            var data1 = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var data2 = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            // Add the point
            cluster1.Points.Add(data1);
            cluster2.Points.Add(data2);

            Assert.Equal(1, cluster1.Points.Count);
            Assert.Equal(1, cluster2.Points.Count);
            Assert.Equal(cluster1, cluster2);
        }

        [Fact]
        public void ClustersHaveSameHashcodeTest()
        {
            var cluster1 = new Cluster<double>();
            var cluster2 = new Cluster<double>();
            var data1 = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var data2 = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            // Add the point
            cluster1.Points.Add(data1);
            cluster2.Points.Add(data2);

            Assert.Equal(1, cluster1.Points.Count);
            Assert.Equal(1, cluster2.Points.Count);
            Assert.Equal(cluster1.GetHashCode(), cluster2.GetHashCode());
        }

        [Fact]
        public void NullClustersAreNotEqualTest()
        {
            var cluster = new Cluster<double>();
            var data = Vector<double>.Build.DenseOfArray(new double[] { 83.28498173551634, 58.96860806993209 });

            // Add the point
            cluster.Points.Add(data);

            Assert.False(cluster.Equals(null));
        }

        [Fact]
        public void ClustersAreEquaObjectslTest()
        {
            var cluster1 = new Cluster<double>();
            var cluster2 = new Cluster<double>();
            var data1 = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var data2 = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            // Add the point
            cluster1.Points.Add(data1);
            cluster2.Points.Add(data2);

            Assert.Equal(1, cluster1.Points.Count);
            Assert.Equal(1, cluster2.Points.Count);
            Assert.True(cluster1.Equals(cluster2 as object));
        }

        [Fact]
        public void ClusterEqualsSelfTest()
        {
            var cluster = new Cluster<double>();
            var data = Vector<double>.Build.DenseOfArray(new double[] { 83.28498173551634, 58.96860806993209 });

            // Add the point
            cluster.Points.Add(data);

            Assert.True(cluster.Equals(cluster));
        }
    }
}