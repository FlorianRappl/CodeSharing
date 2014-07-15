using System;

namespace CodeSharing.Pcl04
{
    public interface ITracker
    {
        Double Distance { get; }

        Boolean IsTracking { get; }

        void Start();

        void Stop();
    }
}
