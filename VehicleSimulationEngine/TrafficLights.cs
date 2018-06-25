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
        //define cycle
        //boundingBox? to check when there is a need to stop?        
        // relation of bbx intersection, distance(vehicle - TL), currentSpeed, nextRedTime - currentTime (timeToRed)
        // if (currentSpeed * timeToRed < dist(tlPt - vPt))   //if distance you can travel before it turns red < distance to traffic light

        //import
        public double currentTime;
        public double iterations;

        private double cycleDuration;
        private double[] startTimes;
        private string[] startColours;

        // create booleans
        public bool green;
        public bool amberRed;
        public bool red;
        public bool amberGreen;

        //calculate
        public double timeToRed;
        private double nextTime;
        public void Timing() //set booleans for traffic lights
        {
            for (int j = 0; j < iterations; j++)
            {
                if (currentTime < cycleDuration * j)
                {
                    for (int i = 0; i < startTimes.Length; i++)
                    {
                        if (startTimes.Length == i + 1)
                            nextTime = cycleDuration * j;
                        else
                            nextTime = startTimes[i + 1] * j;
                        if (currentTime > startTimes[i]*j && currentTime < nextTime)
                        {
                            green = false;
                            amberRed = false;
                            red = false;
                            amberGreen = false;
                            if (startColours[i] == "amberRed")
                            {
                                amberRed = true;
                                timeToRed = startTimes[i + 1]*j - currentTime;
                            }
                            else if (startColours[i] == "red")
                                red = true;
                            else if (startColours[i] == "amberGreen")
                                amberGreen = true;
                            else if (startColours[i] == "green")
                                green = true;
                            break;
                        }
                    }
                }
            }

        }
        public void TlBbx() //create traffic light bounding box (or other way to measure when coming to TL)
        {

        }


       
        
    }
}
