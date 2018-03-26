namespace DbScan.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MathNet.Numerics.LinearAlgebra;
    using Xunit;

    public class DbScanClustererTests
    {
        [Fact]
        public void ClusterTest()
        {
            var points = new Vector<double>[]
            {
                Vector<double>.Build.DenseOfArray(new double[] { 83.08303244924173, 58.83387754182331 }),
                Vector<double>.Build.DenseOfArray(new double[] { 45.05445510940626, 23.469642649637535 }),
                Vector<double>.Build.DenseOfArray(new double[] { 14.96417921432294, 69.0264096390456 }),
                Vector<double>.Build.DenseOfArray(new double[] { 73.53189604333602, 34.896145021310076 }),
                Vector<double>.Build.DenseOfArray(new double[] { 73.28498173551634, 33.96860806993209 }),
                Vector<double>.Build.DenseOfArray(new double[] { 73.45828098873608, 33.92584423092194 }),
                Vector<double>.Build.DenseOfArray(new double[] { 73.9657889183145, 35.73191006924026 }),
                Vector<double>.Build.DenseOfArray(new double[] { 74.0074097183533, 36.81735596177168 }),
                Vector<double>.Build.DenseOfArray(new double[] { 73.41247541410848, 34.27314856695011 }),
                Vector<double>.Build.DenseOfArray(new double[] { 73.9156256353017, 36.83206791547127 }),
                Vector<double>.Build.DenseOfArray(new double[] { 74.81499205809087, 37.15682749846019 }),
                Vector<double>.Build.DenseOfArray(new double[] { 74.03144880081527, 37.57399178552441 }),
                Vector<double>.Build.DenseOfArray(new double[] { 74.51870941207744, 38.674258946906775 }),
                Vector<double>.Build.DenseOfArray(new double[] { 74.50754595105536, 35.58903978415765 }),
                Vector<double>.Build.DenseOfArray(new double[] { 74.51322752749547, 36.030572259100154 }),
                Vector<double>.Build.DenseOfArray(new double[] { 59.27900996617973, 46.41091720294207 }),
                Vector<double>.Build.DenseOfArray(new double[] { 59.73744793841615, 46.20015558367595 }),
                Vector<double>.Build.DenseOfArray(new double[] { 58.81134076672606, 45.71150126331486 }),
                Vector<double>.Build.DenseOfArray(new double[] { 58.52225539437495, 47.416083617601544 }),
                Vector<double>.Build.DenseOfArray(new double[] { 58.218626647023484, 47.36228902172297 }),
                Vector<double>.Build.DenseOfArray(new double[] { 60.27139669447206, 46.606106348801404 }),
                Vector<double>.Build.DenseOfArray(new double[] { 60.894962462363765, 46.976924697402865 }),
                Vector<double>.Build.DenseOfArray(new double[] { 62.29048673878424, 47.66970563563518 }),
                Vector<double>.Build.DenseOfArray(new double[] { 61.03857608977705, 46.212924720020965 }),
                Vector<double>.Build.DenseOfArray(new double[] { 60.16916214139201, 45.18193661351688 }),
                Vector<double>.Build.DenseOfArray(new double[] { 59.90036905976012, 47.555364347063005 }),
                Vector<double>.Build.DenseOfArray(new double[] { 62.33003634144552, 47.83941489877179 }),
                Vector<double>.Build.DenseOfArray(new double[] { 57.86035536718555, 47.31117930193432 }),
                Vector<double>.Build.DenseOfArray(new double[] { 58.13715479685925, 48.985960494028404 }),
                Vector<double>.Build.DenseOfArray(new double[] { 56.131923963548616, 46.8508904252667 }),
                Vector<double>.Build.DenseOfArray(new double[] { 55.976329887053, 47.46384037658572 }),
                Vector<double>.Build.DenseOfArray(new double[] { 56.23245975235477, 47.940035191131756 }),
                Vector<double>.Build.DenseOfArray(new double[] { 58.51687048212625, 46.622885352699086 }),
                Vector<double>.Build.DenseOfArray(new double[] { 57.85411081905477, 45.95394361577928 }),
                Vector<double>.Build.DenseOfArray(new double[] { 56.445776311447844, 45.162093662656844 }),
                Vector<double>.Build.DenseOfArray(new double[] { 57.36691949656233, 47.50097194337286 }),
                Vector<double>.Build.DenseOfArray(new double[] { 58.243626387557015, 46.114052729681134 }),
                Vector<double>.Build.DenseOfArray(new double[] { 56.27224595635198, 44.799080066150054 }),
                Vector<double>.Build.DenseOfArray(new double[] { 57.606924816500396, 46.94291057763621 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.18714230041951, 13.877149710431695 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.449448810657486, 13.490778346545994 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.295018390286714, 13.264889000216499 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.160201832884923, 11.89278262341395 }),
                Vector<double>.Build.DenseOfArray(new double[] { 31.341509791789576, 15.282655921997502 }),
                Vector<double>.Build.DenseOfArray(new double[] { 31.68601630325429, 14.756873246748 }),
                Vector<double>.Build.DenseOfArray(new double[] { 29.325963742565364, 12.097849250072613 }),
                Vector<double>.Build.DenseOfArray(new double[] { 29.54820742388256, 13.613295356975868 }),
                Vector<double>.Build.DenseOfArray(new double[] { 28.79359608888626, 10.36352064087987 }),
                Vector<double>.Build.DenseOfArray(new double[] { 31.01284597092308, 12.788479208014905 }),
                Vector<double>.Build.DenseOfArray(new double[] { 27.58509216737002, 11.47570110601373 }),
                Vector<double>.Build.DenseOfArray(new double[] { 28.593799561727792, 10.780998203903437 }),
                Vector<double>.Build.DenseOfArray(new double[] { 31.356105766724795, 15.080316198524088 }),
                Vector<double>.Build.DenseOfArray(new double[] { 31.25948503636755, 13.674329151166603 }),
                Vector<double>.Build.DenseOfArray(new double[] { 32.31590076372959, 14.95261758659035 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.460413702763617, 15.88402809202671 }),
                Vector<double>.Build.DenseOfArray(new double[] { 32.56178203062154, 14.586076852632686 }),
                Vector<double>.Build.DenseOfArray(new double[] { 32.76138648530468, 16.239837325178087 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.1829453331884, 14.709592407103628 }),
                Vector<double>.Build.DenseOfArray(new double[] { 29.55088173528202, 15.0651247180067 }),
                Vector<double>.Build.DenseOfArray(new double[] { 29.004155302187428, 14.089665298582986 }),
                Vector<double>.Build.DenseOfArray(new double[] { 29.339624439831823, 13.29096065578051 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.997460327576846, 14.551914158277214 }),
                Vector<double>.Build.DenseOfArray(new double[] { 30.66784126125276, 16.269703107886016 }),
            };

            var transformer = new DBScanClusterer<double>(2.0, 5);
            var clusters = transformer.Cluster(points);

            Assert.Equal(3, clusters.Count());

            var clusterOne = new List<Vector<double>>(new[]
                            {
                              points[3], points[4], points[5], points[6],
                              points[7], points[8], points[9], points[10],
                              points[11], points[12], points[13], points[14],
                            });
            var clusterTwo = new List<Vector<double>>(new[]
                            {
                              points[15], points[16], points[17], points[18],
                              points[19], points[20], points[21], points[22],
                              points[23], points[24], points[25], points[26],
                              points[27], points[28], points[29], points[30],
                              points[31], points[32], points[33], points[34],
                              points[35], points[36], points[37], points[38],
                            });
            var clusterThree = new List<Vector<double>>(new[]
                            {
                                points[39], points[40], points[41], points[42],
                                points[43], points[44], points[45], points[46],
                                points[47], points[48], points[49], points[50],
                                points[51], points[52], points[53], points[54],
                                points[55], points[56], points[57], points[58],
                                points[59], points[60], points[61], points[62],
                            });
            bool cluster1Found = false;
            bool cluster2Found = false;
            bool cluster3Found = false;
            foreach (var cluster in clusters)
            {
                if (cluster.Points.All(point => clusterOne.Contains(point)))
                {
                    cluster1Found = true;
                }

                if (cluster.Points.All(point => clusterTwo.Contains(point)))
                {
                    cluster2Found = true;
                }

                if (cluster.Points.All(point => clusterThree.Contains(point)))
                {
                    cluster3Found = true;
                }
            }

            Assert.True(cluster1Found);
            Assert.True(cluster2Found);
            Assert.True(cluster3Found);
        }

        [Fact]
        public void SingleLinkTest()
        {
            var points = new Vector<double>[]
            {
                Vector<double>.Build.DenseOfArray(new double[] { 10, 10 }), // A
                Vector<double>.Build.DenseOfArray(new double[] { 12, 9 }),
                Vector<double>.Build.DenseOfArray(new double[] { 10, 8 }),
                Vector<double>.Build.DenseOfArray(new double[] { 8, 8 }),
                Vector<double>.Build.DenseOfArray(new double[] { 8, 6 }),
                Vector<double>.Build.DenseOfArray(new double[] { 7, 7 }),
                Vector<double>.Build.DenseOfArray(new double[] { 5, 6 }),  // B
                Vector<double>.Build.DenseOfArray(new double[] { 14, 8 }), // C
                Vector<double>.Build.DenseOfArray(new double[] { 7, 15 }), // N - Noise, should not be present
                Vector<double>.Build.DenseOfArray(new double[] { 17, 8 }), // D - single-link connected to C should not be present
            };

            var clusterer = new DBScanClusterer<double>(3, 3);
            var clusters = clusterer.Cluster(points);

            Assert.Single(clusters);

            var clusterFound = false;
            var clusterOne = new List<Vector<double>>(new[]
                                                {
                                                    points[0], points[1],
                                                    points[2], points[3],
                                                    points[4], points[5],
                                                    points[6], points[7],
                                                });
            foreach (var cluster in clusters)
            {
                if (cluster.Points.All(point => clusterOne.Contains(point)))
                {
                    clusterFound = true;
                }
            }

            Assert.True(clusterFound);
        }

        [Fact]
        public void GetEpsilonTest()
        {
            var clusterer = new DBScanClusterer<double>(2.0, 5);
            Assert.Equal(2.0, clusterer.Epsilon, 5);
        }

        [Fact]
        public void GetMinPtsTest()
        {
            var clusterer = new DBScanClusterer<double>(2.0, 5);
            Assert.Equal(5, clusterer.MinPts);
        }

        [Fact]
        public void NegativeEpsilonTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DBScanClusterer<double>(-2.0, 5));
        }

        [Fact]
        public void NegativeMinPtsTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DBScanClusterer<double>(2.0, -5));
        }

        [Fact]
        public void NullDatasetTest()
        {
            Assert.Throws<ArgumentNullException>(() => new DBScanClusterer<double>(2.0, 5).Cluster(null));
        }

        [Fact]
        public void NullDistanceMeasureTest()
        {
            Assert.Throws<ArgumentNullException>(() => new DBScanClusterer<double>(2.0, 5, null));
        }
    }
}
