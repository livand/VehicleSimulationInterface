using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    class TrafficLights
    {
        //assign trafficLight to roadPt      

        //import
        public double currentTime;
        public double iterations;

        private double cycleDuration;

        private double currentCycleDuration;

        private Dictionary<String, double> cycleDurations = new Dictionary<string, double>();

        // create booleans
        public bool green;
        public bool amberRed;
        public bool red;
        public bool amberGreen;

        //calculate
        private double lastChangeTimeStep = 0;

        public TrafficLights(bool red = true, bool amberGreen = false, bool green = false, bool amberRed = false)
        {
            cycleDurations = new Dictionary<string, double>();
            cycleDurations.Add("Red", 30);
            cycleDurations.Add("AmberGreen", 0);
            cycleDurations.Add("Green", 30);
            cycleDurations.Add("AmberRed", 0);

            this.red = red;
            this.amberGreen = amberGreen;
            this.green = green;
            this.amberRed = amberRed;

            currentCycleDuration = cycleDurations["Red"];
        }

        public void Timing(double currentTimeStep) //set booleans for traffic lights
        {
            if((currentTimeStep - lastChangeTimeStep) > currentCycleDuration)
            {
                //Time to change the light
                if(red)
                {
                    red = false;
                    amberGreen = true;
                    currentCycleDuration = cycleDurations["AmberGreen"];
                }
                else if (amberGreen)
                {
                    amberGreen = false;
                    green = true;
                    currentCycleDuration = cycleDurations["Green"];
                }
                else if (green)
                {
                    green = false;
                    amberRed = true;
                    currentCycleDuration = cycleDurations["AmberRed"];
                }
                else if (amberRed)
                {
                    amberRed = false;
                    red = true;
                    currentCycleDuration = cycleDurations["Red"];
                }

                lastChangeTimeStep = currentTimeStep;
            }

        }

        public void tlPosition()
        {
            //List all the points connected to a traffic light            
        }
               
    }
}
