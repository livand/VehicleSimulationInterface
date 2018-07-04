using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    class Distribution
    {
        
        private Dictionary<string, double> vehicleDistribution = new Dictionary<string, double>(); //IMPORT (name, percentage)
        string profile;


        public string FindProfiles()
        {
            
            foreach(string p in vehicleDistribution.Keys)
            {
                //if we use the current string, assign profile
                profile = p;
            }

            return profile;
        }

        public void VehiclesPerRoad(int totNrOfVeh)
        {
            //if keys match, multiply percentage double with nrOfVeh
            int nrOfVeh = Convert.ToInt32(Math.Ceiling(totNrOfVeh * vehicleDistribution[profile]*0.01)); //multiply total vehicles * percentage(profile) * 0.01

        }

        public void StartTime()
        {

        }
    }
}
