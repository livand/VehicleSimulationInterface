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
        private double stopMargin; //how much distance it will leave to objects ahead (meters / points?) //ax from Francis formula
        private double bx_add = 0.2;
        private double bx_mul = 0.3;


        private double timeStep;

        //Import vehicle geometry from input
        private double width;
        private double length;
        private double backToAx; //Distance between rear axel and back of vehicle
        private Point vehPosition = new Point(0, 0, 0); //Centre point of the vehicle on the road
        private double distanceTravelled;
        private double accFactor;

        private List<Point> roadPts = new List<Point>();
        private List<double> roadSpeed = new List<double>();
        private List<Point> boundingPts = new List<Point>();
        private List<double> boundingSpeed = new List<double>();

        private double CalculateRandom()
        {
            Random rnd = new Random();
            double z = rnd.NextDouble(); //give range to z [0,1.0] mean 0.5, sd 0.15
            return z;
        }

        private int CalculateStopMargin() //Calculate the stop margin in points (int) from the number of seconds of safety margin and the current speed
        {
            int stop = 0;
            int ptDist = 1; //Obtain from engine later
            double result = stopMargin + length - backToAx; //assign apropriate car lenght: right now, centerPt of back axis
            stop = Convert.ToInt32(Math.Ceiling(result / ptDist));

            return stop;
        }

        private int CalculateSafetyMargin() //Calculate the safety margin in points (int) from the number of seconds of safety margin and the current speed
        {
            int safety = 0;
            double result = CalculateStopMargin() + (bx_add + bx_mul * CalculateRandom()) * Math.Sqrt(currentSpeed);   

            int ptDist = 1; //Obtain from engine later
            safety = Convert.ToInt32(Math.Ceiling(result / ptDist));

            return safety;
        }
        
        public int SafetyCount()
        {            
            int safety = CalculateSafetyMargin();
            int stop = CalculateStopMargin();
            int safetyCount = (((currentIndex + safety) < roadPts.Count) ? (currentIndex + safety) : roadPts.Count);
            return safetyCount;
        }
        public Point NextPoint()
        {
            Point nextPt = ((currentIndex + 1) < roadPts.Count ? roadPts[currentIndex + 1] : roadPts[currentIndex]); //DEFINE ELSE-POINT IF NO POINTS AHEAD
            return nextPt;
        }

        public void BoundingPolygon()
        {
            boundingPts.Clear();
            Point basePt = new Point();            
            Vector direction = Point.Subtract(NextPoint(), roadPts[currentIndex]);           

            for (int i = currentIndex; i < SafetyCount(); i++)
            {
                boundingPts.Add(roadPts[i]);
                boundingSpeed.Add(roadSpeed[i]);
            }           
        }
        public Tuple<double,double> NextSpeed()
        {
            int ptDist = 1; //Obtain from engine later
            double breakDist = 0;
            double nextSpeed = Math.Min((currentSpeed < roadSpeed[currentIndex] ? roadSpeed[currentIndex] : currentSpeed), maxSpeed); //Smallest value of speed limit / max speed
            for (int i = 0; i < boundingSpeed.Count; i++)
            {                
                if (nextSpeed > boundingSpeed[i]) //if speedLimit ahead is smaller than nextSpeed, set the lower limit
                {
                    nextSpeed = boundingSpeed[i];
                    breakDist = i * ptDist;
                }
            }
            return Tuple.Create(nextSpeed, breakDist);            
        }
               


        bool absoluteStop;//insert booleans from traffic lights / obstacles
        public void Accelerate(double nextSpeed, double breakDist) //GET NEXT SPEED IN HERE
        {
            double a = ((nextSpeed * nextSpeed) - (currentSpeed * currentSpeed)) / (2 * breakDist);             // a=(v1*v1-v2*v2) / (2*s)
            double aSpeed = 0; //calculate acceleration reference: if you have to accelerate harder than this; use standard acceleration
            double aBrake = 0; //calculate acceleration reference: if you have to break harder than this; don't brake
            double aMaxBrake = 0;
            if (a >= 0)
                accFactor = Math.Min(a, aSpeed);
            else if (a <= aBrake && absoluteStop == false)      //set red to absoluteStop = true; amberRed to absoluteStop = false;
                accFactor = 0;
            else if (a < 0)
                accFactor = Math.Max(a, aMaxBrake);
        }    

        public void Update(double timeStep)
        {
            double distance = currentSpeed * timeStep + 0.5 * accFactor * timeStep * timeStep;    // s = v1*t + (1/2)*a*t*t
            distanceTravelled += Math.Min(distance, maxSpeed*timeStep);
            currentSpeed = distance / timeStep;
        }
    }
}
