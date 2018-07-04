using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    public class Road
    {
        private Guid id;
        public Guid RoadID { get { return id; } }

        List<RoadSegment> roadSegments;
        
        public Road()
        {
            roadSegments = new List<RoadSegment>();
            id = Guid.NewGuid();
        }

        public void AddRoadSegment(RoadSegment rs)
        {
            if (!ContainsRoadSegment(rs))
                roadSegments.Add(rs);
        }

        public bool ContainsRoadSegment(RoadSegment rs)
        {
            return roadSegments.Where(x => x.RoadSegmentID == rs.RoadSegmentID).FirstOrDefault() != null;
        }

    }
}
