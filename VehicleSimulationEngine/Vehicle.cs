using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    /*
     * Vehicle class is to contain only all data relevant to a finished vehicle ready to move 
     * Any calculations should occur in an interface or engine
     * Any calculations should be hidden from Andrew before he breaks them
     */
    public class Vehicle
    {
        //construct all the vehicle properties here?

        //Type name, example: Toyota
        private string vehicleName;
        private int currentIndex;

        //Import maxSpeed from input + speedLimit from Road
        private double maxSpeed;
        private double currentSpeed; // neeeded here?
        private double safetyMargin; //how far ahead from stopMargin it will look for obstacles (seconds) //Number of seconds of safety
        private int stopMargin; //how much distance it will leave to objects ahead (meters / points?) //See above

        private double timeStep;

        //Import vehicle geometry from input
        private double width;
        private double length;
        private double frontToAx; //Distance between front axel and front of vehicle
        private double backToAx; //Distance between rear axel and back of vehicle
        private Point vehPosition = new Point(0,0,0); //Centre point of the vehicle on the road
        private double distanceTravelled;
        private double accFactor;

        private List<Point> roadPts = new List<Point>();
        private List<Point> boundingPts = new List<Point>();

        //construct obstacle bounding box depending on speed, stopMargin & safetyMargin
        public void BoundingPolygon()
        {
            boundingPts.Clear();

            //Create the bounding polygon based on the vehicle size and length of its stop margin
            Point basePt = new Point();

            //Calculate the current position of the front of the car from the vector from the current centre point to the next road point in the direction of travel
            //From the basePt (front of vehicle) add the safety margin
            int safety = CalculateSafetyMargin();
            Point nextPt = ((currentIndex + 1) < roadPts.Count ? roadPts[currentIndex + 1] : roadPts[currentIndex]); //DEFINE ELSE-POINT IF NO POINTS AHEAD
            Vector direction = Point.Subtract(nextPt, roadPts[currentIndex]);
            

            //Add the safety margin to the index of the current base point
            //The resulting point at that index is the furtherest point from the car within the safety region - giving the bounding box
            int safetyCount = (((currentIndex + safety) < roadPts.Count) ? (currentIndex + safety) : roadPts.Count);

            for (int i = currentIndex; i < safetyCount; i++)
            {
                boundingPts.Add(roadPts[i]);
            }
            


        }

        private int CalculateSafetyMargin()
        {
            //Calculate the safety margin in points (int) from the number of seconds of safety margin and the current speed
            int safety = 0;

            double result = currentSpeed * safetyMargin; //s=v*t

            //To-DO - obtain point distance from global engine
            int ptDistance = 1; //Obtain from engine later
            safety = Convert.ToInt32(Math.Ceiling(result / ptDistance));

            return safety;
        }

        public void Accelerate(double target)
        {
            accFactor = (target-currentSpeed) / safetyMargin;
        }

        public void AccelerateIn(double target, double distance)
        {
            double a = ((target * target) - (currentSpeed * currentSpeed)) / (2 * distance);
            double a2 = (target - currentSpeed / (safetyMargin-timeStep));
            if(a <= a2) //if you have to break harder than your safetyMargin allows, don't break
            {
                accFactor = a;
            }
        }        


        public void Update(double timeStep)
        {
            double distance = currentSpeed * timeStep + 0.5 * accFactor * timeStep * timeStep;    // s = v1*t + (1/2)*a*t*t
            distanceTravelled += Math.Min(distance, maxSpeed*timeStep);
            currentSpeed = distance / timeStep;
        }
    }
}
