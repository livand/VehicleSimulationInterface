using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector Subtract(Point pt, Point pt2)
        {
            Vector v = new Vector
            {
                X = (pt.X - pt2.X),
                Y = (pt.Y - pt2.Y),
                Z = (pt.Z - pt2.Z)
            };

            return v;
        }
    }
}
