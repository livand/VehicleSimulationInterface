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

        public void CheckForBreak() //Do I even need this here? NextSpeed is in vehicle, and already contains the speeding up / speeding down
        {
            nextSpeed = NextSpeed(1);
           
            veh.Accelerate(Math.Min(nextSpeed,speedLimit));             

            //if bbMargin intersect traffic light //NO!! change the speed for the road point closest to the traffic light!! or?!?!?!
            if (amberRed || red)  
            {
                veh.AccelerateIn(0,distToTl); // a=(v1*v1-v2*v2) / (2*s)
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
