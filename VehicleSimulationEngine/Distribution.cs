using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    class Distribution
    {
        //TO IMPORT
        List<string> carTypes;
        List<double> percentageDistribution;
        int nrOfCars;

        public void CarsPerRoad()
        {
            List<double> distribution = new List<double>();
            foreach (double d in percentageDistribution)
            {
                distribution.Add(Math.Round((d/100) * nrOfCars));
            }
            
            //depending on vehicle types
            //depending on amount of roads
            //depending on distribution settings
        }
    }
}
