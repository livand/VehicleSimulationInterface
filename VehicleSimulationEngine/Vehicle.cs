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
        double[] vehicleInfo;

        public double[] SetVehicleInfo() //take inputs from interface and put here!
        {
            vehicleInfo[0] = length;
            vehicleInfo[1] = width;
            vehicleInfo[2] = frontToAx;
            vehicleInfo[3] = backToAx;
            vehicleInfo[4] = stopMargin;
            vehicleInfo[5] = maxSpeed;
            //vehicleInfo[6] = maxAcc;
            //vehicleInfo[7] = maxBrake;

            return vehicleInfo;
        }

        private int currentIndex;

        //Import maxSpeed from input + speedLimit from Road
        private double maxSpeed;
        private double currentSpeed; // neeeded here?
        
        private double bx_add = 0.2;
        private double bx_mul = 0.3;


        private double timeStep;

        //Import vehicle geometry from input (array?)
        private double width;
        private double length;
        private double frontToAx;
        private double backToAx; //Distance between rear axel and back of vehicle
        private double stopMargin; //how much distance it will leave to objects ahead (meters / points?) //ax from Francis formula

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

        private int CalculateStopMargin()
        {
            int stop = 0;
            int ptDist = 1; //Obtain from engine later
            double result = stopMargin + length - backToAx; //right now, centerPt of back axis as output
            stop = Convert.ToInt32(Math.Ceiling(result / ptDist));

            return stop;
        }

        private int CalculateSafetyMargin()
        {
            int safety = 0;
            int ptDist = 1; //Obtain from engine later
            double result = CalculateStopMargin() + (bx_add + bx_mul * CalculateRandom()) * Math.Sqrt(currentSpeed);               
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
                       
            for (int i = currentIndex; i < SafetyCount(); i++)
            {
                boundingPts.Add(roadPts[i]);
                boundingSpeed.Add(roadSpeed[i]);
            }           
        }
        public void VehicleAngle()
        {
            Vector zeroVec = new Vector(1,0,0);        //as defined in SmartMove
            Vector direction = Point.Subtract(NextPoint(), roadPts[currentIndex]);
            double angleBetween = Vector.AngleBetween(zeroVec,direction); //Set AngleBetween in Vector class        
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
            double aSpeed = 0; //set acceleration reference: if you have to accelerate harder than this; use standard acceleration
            double aBrake = 0; //set acceleration reference: if you have to brake harder than this; don't brake
            double aMaxBrake = 0; //calculate the hardest acc a vehicle can have when braking
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
            currentSpeed = distance / timeStep;
            int ptDist = 1; //Obtain from engine later
            currentIndex = Convert.ToInt32(Math.Ceiling(currentIndex + distance / ptDist)); 
        }
    }
}
