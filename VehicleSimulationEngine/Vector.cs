using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static double AngleBetween(Vector v1,Vector v2)
        {
            double angle = Math.Atan2(v1.Y - v2.Y, v1.X - v2.X); //2D as handled in Smartmove, do we need 3D in a later stage?
            return angle;
        }
    }
}
