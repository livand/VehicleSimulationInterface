using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleSimulationEngine
{
    public class Speed
    {
        

        //import distance between points ptDist [m]
        double ptDist = 0.1;

        //import time step [seconds]

        //import speed for curve segment crvSpeed
        private double crvSpeed;
        private double currentSpeed;
        private double ptStep;
        private double timeStep; //need to be calculated from the timestep input
        private double result;

        public double CrvSpeed { set { crvSpeed = value; } }
       // public double Time { set { time = value; } }
        public double Result { get { return ptStep; } }


        public void Calculate()
        {
            //Values TO BE REPLACED WITH INPUTS
            timeStep = 1;

            currentSpeed = crvSpeed; //CALCULATE DUE TO DEPENDENCIES : obstacles etc

            ptStep = (currentSpeed * timeStep) / ptDist;
        }

        //Assign speed to each of the curve points. Currently, use curve speed for all points. Later, vary with obstacles / changes.

        // Calculate ptSteps = (v*t)/ptDist

        //return ptSteps
    }
}
