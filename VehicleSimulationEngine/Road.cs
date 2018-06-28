using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    class Road
    {
        List<int> segmentID = new List<int>();

        //private Dictionary<Point, double> roadProperties = new Dictionary<Point, double>();
        private List<RoadSegment> roadProperties = new List<RoadSegment>();
        public void AddRoadAssembly(List<RoadSegment> segments)
        {
            foreach (RoadSegment rs in segments)
                if (!roadProperties.Contains(rs))
                    roadProperties.Add(rs);
        }

                        

    }
}
