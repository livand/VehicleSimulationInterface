using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    class RoadSegment
    {
        private Dictionary<Point, double> roadSegments = new Dictionary<Point, double>();

        //Import all points for segment
        //Apply speed to all point
        private void ConstructSegment(double segmentSpeed, List<Point>segmentPts)
        {
            foreach (Point p in segmentPts)
            {
                roadSegments.Add(p, segmentSpeed);
            }
        }
    }
}
