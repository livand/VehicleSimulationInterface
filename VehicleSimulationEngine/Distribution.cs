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
        public Dictionary<string, double> VehicleDistribution { get { return vehicleDistribution; } }
        List<double> vehicleNr = new List<double>();


        public void VehiclesPerRoad(int totNrOfVeh)
        {
            //if keys match, multiply percentage double with nrOfVeh
            foreach (string profile in vehicleDistribution.Keys)
            {
                int nrOfVeh = Convert.ToInt32(Math.Ceiling(totNrOfVeh * vehicleDistribution[profile] * 0.01)); //multiply total vehicles * percentage(profile) * 0.01
                vehicleNr.Add(nrOfVeh);
            }
        }

        public void StartTime()
        {

        }
    }
}
