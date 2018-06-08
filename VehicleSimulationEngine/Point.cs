using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulationEngine
{
    public class Point
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        //double T { get; set; } //4D point - probably not required...

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
    }
}
