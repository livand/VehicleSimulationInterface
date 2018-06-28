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

        public void VehiclesPerRoad(int totNrOfVeh)
        {
            //if keys match, multiply percentage double with nrOfVeh
            int nrOfVeh = Convert.ToInt32(Math.Ceiling(totNrOfVeh * ));

        }
    }
}
