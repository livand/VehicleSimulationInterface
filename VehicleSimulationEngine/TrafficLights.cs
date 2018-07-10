using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    public class TrafficLights
    {
        public enum TrafficLight { tOff = 0, tRed, tAmberRed, tGreen, tAmberGreen };
        private TrafficLight currentLight = TrafficLight.tOff;
        public TrafficLight CurrentLightDisplayed { get { return currentLight; } }
        //assign trafficLight to roadPt      
        private Point tLightLocation;
        public Point TrafficLightLocation { get { return tLightLocation; } set { tLightLocation = value; } }

        //import
        public double currentTime; //get globally
        public double iterations;

        private double cycleDuration;

        private double currentCycleDuration;

        private Dictionary<String, double> cycleDurations = new Dictionary<string, double>();

        //calculate
        private double lastChangeTimeStep = 0;

        private Guid id;
        public Guid TrafficLightID { get { return id; } }

        public TrafficLights(TrafficLight currentLight)
        {
            cycleDurations = new Dictionary<string, double>();
            cycleDurations.Add("Red", 30);
            cycleDurations.Add("AmberGreen", 0);
            cycleDurations.Add("Green", 30);
            cycleDurations.Add("AmberRed", 0);

            this.currentLight = currentLight;

            id = Guid.NewGuid();

            currentCycleDuration = cycleDurations["Red"];
        }

        public void Timing(double currentTimeStep) //set booleans for traffic lights
        {
            if((currentTimeStep - lastChangeTimeStep) > currentCycleDuration)
            {
                //Time to change the light
                if(currentLight == TrafficLight.tRed)
                {
                    currentLight = TrafficLight.tAmberGreen;
                    currentCycleDuration = cycleDurations["AmberGreen"];
                }
                else if (currentLight == TrafficLight.tAmberGreen)
                {
                    currentLight = TrafficLight.tGreen;
                    currentCycleDuration = cycleDurations["Green"];
                }
                else if (currentLight == TrafficLight.tGreen)
                {
                    currentLight = TrafficLight.tAmberRed;
                    currentCycleDuration = cycleDurations["AmberRed"];
                }
                else if (currentLight == TrafficLight.tAmberRed)
                {
                    currentLight = TrafficLight.tRed;
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
