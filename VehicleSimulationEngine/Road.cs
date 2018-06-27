using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    class Road
    {
        //Add list with segment keys in pre-set order as to inputs
        List<int> segmentID = new List<int>();


        private Dictionary<Point, double> roadProperties = new Dictionary<Point, double>();
        public void AddRoadAssembly(Dictionary<Point, double> segmentProperties)
        {
            foreach (KeyValuePair<Point, double> kvp in segmentProperties)
                if (!roadProperties.ContainsKey(kvp.Key))
                    roadProperties.Add(kvp.Key, kvp.Value);
        }

        private Dictionary<Point, double> tlProperties = new Dictionary<Point, double>();  //tl point, ID

        public void hasTrafficLight()
        {
            //find out if road contains traffic light (if traffic light is connected to road component)
            //1. Import list of tlID (as connected to the road)
            //2. Match tlID with properties from TrafficLight class (timings etc)
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

        public void updatePtSpeed()
        {
            //when traffic light is red or amberRed, apply speed 0 to point
            //when traffic light is green or amberGreen, apply standard speed to point
            
        }

    }
}
