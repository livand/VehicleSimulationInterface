using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    public class RoadSegment
    {
        private Guid id;
        public Guid RoadSegmentID { get { return id; } } //Future work - allow Guid to be set from the Rhino data/incoming data so allow ID to be set externally

        private List<TrafficLights> trafficLights;

        private Dictionary<Point, double> originalRoadSegmentSpeeds;
        private Dictionary<Point, double> roadSegmentPts;// = new Dictionary<Point, double>();
        public Dictionary<Point, double> RoadSegments { get { return roadSegmentPts; } }

        public RoadSegment()
        {
            trafficLights = new List<TrafficLights>();
            roadSegmentPts = new Dictionary<Point, double>();
            originalRoadSegmentSpeeds = new Dictionary<Point, double>();

            id = Guid.NewGuid();
        }

        public void AddTrafficLight(TrafficLights tLight)
        {
            //Only add a traffic light if it was not already associated to this road segment
            //if (trafficLights.Where(x => x.TrafficLightID == tLight.TrafficLightID).FirstOrDefault() == null)
            if(!HasTrafficLight(tLight))
                trafficLights.Add(tLight);
            //Using a lambada LINQ query to assign each value in the list to the variable of x (x =>)
            /*
             *  The non LINQ equivilant = 
             *  bool inList = false;
             *  foreach(TrafficLights tl in trafficLights)
             *  {
             *      if(tl.TrafficLightID == tLight.TrafficLightID)
             *      {
             *          inList = true;
             *          break;
             *      }
             *  }
             *  if(!inList)
             *      trafficLights.Add(tLight);
             * */
        }

        public void ConstructSegment(double segmentSpeed, List<Point>segmentPts)
        {
            foreach (Point p in segmentPts)
            {
                roadSegmentPts.Add(p, segmentSpeed);
                originalRoadSegmentSpeeds.Add(p, segmentSpeed);
            }            
        }

        public bool HasTrafficLight(TrafficLights tLight)
        {
            //tLight = the Light to be checked

            return trafficLights.Where(x => x.TrafficLightID == tLight.TrafficLightID).FirstOrDefault() != null;


            //find out if road contains traffic light (if traffic light is connected to road component)
            //1. Import list of tlID (as connected to the road)
            //2. Match tlID with properties from TrafficLight class (timings etc)
        }

        public void UpdateSpeedBasedOnLight(TrafficLights tLight, double tolerance = 1.0) //Update to be the distance between points from the engine later
        {
            //Find the closest road point of the segment to the given traffic light
            Point tLoc = tLight.TrafficLightLocation;
            double dist = 1e10;
            Point foundP = null;

            foreach(Point p in roadSegmentPts.Keys)
            {
                double distToPt = p.DistanceTo(tLoc);
                if(distToPt < dist && distToPt <= tolerance)
                {
                    dist = p.DistanceTo(tLoc);
                    foundP = p;
                }
            }

            if(foundP != null)
            {
                //We have a point for this tLight - update its speed based on its current light
                if (tLight.CurrentLightDisplayed == TrafficLights.TrafficLight.tRed || tLight.CurrentLightDisplayed == TrafficLights.TrafficLight.tAmberRed)
                    roadSegmentPts[foundP] = 0;
                else if (tLight.CurrentLightDisplayed == TrafficLights.TrafficLight.tGreen || tLight.CurrentLightDisplayed == TrafficLights.TrafficLight.tAmberGreen)
                    roadSegmentPts[foundP] = originalRoadSegmentSpeeds[foundP]; //Reset speed to original value
            }
        }       
    }
}
