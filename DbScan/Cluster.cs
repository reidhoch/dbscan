using System.Collections.Generic;
namespace DbScan
{
    public class Cluster<T> where T : IClusterable
    {
        public IList<T> Points { get; private set; }

        public Cluster()
        {
            Points = new List<T>();
        }
    }
}