using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    public class Moving
    {
        public Moving()
        {
            vehiclePtStep = new List<int>();
        }

        //create lists for output
        public List<int> vehiclePtStep;
        public double ptStep;
        public double newSpeed;
        public double nextSpeed;


        //input / import
        public double currentSpeed;
        
        public double ptDist;
        public double timeStep;

        //import from road
        public double speedLimit; 

        // import from vehicle
        public double maxSpeed; 
        public double safetyMargin;
        public double stopMargin;

        //import from TrafficLights
        public bool green;
        public bool amberRed; //Going from amber to red not displaying amber and red at same time
        public bool red;
        public bool amberGreen;
        public double timeToRed;
        private Vehicle veh;

        public double distToTl; // 

        //Check breaking foreach vehicle

        public void CheckForBreak()
        {
            nextSpeed = 1; //find speed assigned to point in distance of safetyMargin.
           
            veh.Accelerate(Math.Min(nextSpeed,speedLimit)); // a = (v2-v1)/t             

            //if bbMargin intersect traffic light
            if (amberRed || red)  
            {
                veh.AccelerateIn(0,distToTl); // a=(v1*v1-v2*v2) / (2*s)
                
                // if breakfactor is safe and amberRed or red (how define?!?!?!?!?!)

            }
           

        }

        public bool accBool;
        public double accFactor;
        public void CheckForAcc()
        {
            if (speedLimit > currentSpeed && speedLimit < maxSpeed && breakFactor >= 0)
            {
                accFactor = (nextSpeed - currentSpeed) / safetyMargin;
            }
                    
        }


    }
}
