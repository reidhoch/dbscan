namespace DbScan.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbScan.Distance;
    using MathNet.Numerics.LinearAlgebra;
    using Xunit;

    public class DistanceMeasureTests
    {
        [Fact]
        public void SameChebyshevDistanceTest()
        {
            var measure = new ChebyshevDistance<double>();
            Assert.NotNull(measure);

            var pointA = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var pointB = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            Assert.Equal<double>(0.0d, measure.Compute(pointA, pointB));
        }

        [Fact]
        public void SameEuclideanDistanceTest()
        {
            var measure = new EuclideanDistance<double>();
            Assert.NotNull(measure);

            var pointA = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var pointB = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            Assert.Equal<double>(0.0d, measure.Compute(pointA, pointB));
        }

        [Fact]
        public void SameManhattanDistanceTest()
        {
            var measure = new ManhattanDistance<double>();
            Assert.NotNull(measure);

            var pointA = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var pointB = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            Assert.Equal<double>(0.0d, measure.Compute(pointA, pointB));
        }

        [Fact]
        public void SameMinkowskiDistanceTest()
        {
            var measure = new MinkowskiDistance<double>();
            Assert.NotNull(measure);

            var pointA = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var pointB = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            Assert.Equal<double>(0.0d, measure.Compute(pointA, pointB));
        }

        [Fact]
        public void RoundtripPTest()
        {
            var measure = new MinkowskiDistance<double>(3.0);
            Assert.NotNull(measure);

            var pointA = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });
            var pointB = Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 });

            Assert.Equal<double>(3.0d, measure.P);
        }

        [Fact]
        public void NegativePTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MinkowskiDistance<double>(-1.0d));
        }

        [Fact]
        public void PisNaNTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MinkowskiDistance<double>(double.NaN));
        }
    }
}