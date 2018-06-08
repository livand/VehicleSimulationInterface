using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleSimulationEngine
{
    public class Speed
    {
        //import pointlist
        public List<Point> PointList { get; set; }

        //import distance between points ptDist [m]
        double ptDist = 0.1;

        //import time step [seconds]

        //import speed for curve segment crvSpeed
        public double CrvSpeed;
        
        double currentSpeed = 0;

        //Assign speed to each of the curve points. Currently, use curve speed for all points. Later, vary with obstacles / changes.
        
        // Calculate ptSteps = (v*t)/ptDist
        
        //return ptSteps
    }
}
