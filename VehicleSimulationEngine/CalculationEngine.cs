using System;
using System.Collections.Generic;

namespace VehicleSimulationEngine
{
    public class CalculationEngine
    {
        public CalculationEngine()
        {
            //Constructor
            initialList = new List<double>();
            results = new List<double>();
        }

        private List<double> initialList;
        private double addition;
        private List<double> results;

        public List<Double> InitialList {  set { initialList = value; } }
        public double Addition {  set { addition = value; } }
        public List<double> Results {  get { return results; } }

        public void Calculate()
        {
            foreach (double d in initialList)
                results.Add(d + addition);
        }
    }    
}
