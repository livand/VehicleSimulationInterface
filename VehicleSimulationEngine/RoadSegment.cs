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
        public Dictionary<Point, double> RoadSegments { get { return roadSegments; } }

        //Import all points for segment
        //Apply speed to all point
        public void ConstructSegment(double segmentSpeed, List<Point>segmentPts)
        {
            foreach (Point p in segmentPts)
            {
                roadSegments.Add(p, segmentSpeed);
            }            
        }

        public void tlPosition()
        {
            //use tlID
            //find list with location points assigned to the tlID
            //find closest point in tlID and closest point on road: where the traffic light properties should be inserted
            // Point closestPt = tlPoint.DistanceTo(roadPt[0]);     //set first point
            // loop through rest of the roadPts
            // closestPt = (tlPoint.DistanceTo(roadPt[i])

            //in input: have road index defined 
            //Connect traffic light to road
        }

        public void hasTrafficLight()
        {
            //find out if road contains traffic light (if traffic light is connected to road component)
            //1. Import list of tlID (as connected to the road)
            //2. Match tlID with properties from TrafficLight class (timings etc)
        }

        public void updatePtSpeed(Point ptToSee)
        {
            //when traffic light is red or amberRed, apply speed 0 to point
            //when traffic light is red, bool absolute stop = true;
            //when traffic light is green or amberGreen, apply standard speed to point
            RoadSegment segContainsPt = roadProperties.Where(x => x.RoadSegments.ContainsKey(ptToSee)).FirstOrDefault();

            if (segContainsPt != null)
            {
                //Do some stuff to calculate the speed of the road approaching
            }
        }
    }
}
