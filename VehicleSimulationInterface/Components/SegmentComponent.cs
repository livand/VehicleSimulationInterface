using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using VSE = VehicleSimulationEngine;

namespace VehicleSimulationInterface.Components
{
    public class SegmentComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SegmentComponent class.
        /// </summary>
        public SegmentComponent()
          : base("SegmentComponent", "Segment",
              "Construct road segment",
              "BH_Vehicle", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Segment Curve", "crv", "Curve on which the vehicles will operate", GH_ParamAccess.item);
            pManager.AddNumberParameter("Speed Limit", "SL", "Speed limit for segment", GH_ParamAccess.item);
            pManager.AddPointParameter("Traffic Light", "TL", "Assembled traffic light", GH_ParamAccess.list); //Parameter?

            pManager[2].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Segment", "s", "Segment for road construction", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            /*PolyCurve crv = new PolyCurve();
            DA.GetData(0, ref crv);
            var ptDist = 0.1; //get distance from global engine
            Point3d pt = new Point3d();
            List<Point3d> points = new List<Point3d>();
            while((pt = crv.PointAt(ptDist)) != null)
            {
                points.Add(pt);
                ptDist += 0.1;
            }*/
            /*double length = crv.PointAt
            int segment_count = (int)Math.Ceiling(length / ptDist);
            Point3d[] points;
            crv.DivideByCount(segment_count, true, out points);*/
      
            List<VSE.Point> crvPoints = new List<VSE.Point>();
            Random r = new Random();
            for (int x = 0; x < 10; x++)
                crvPoints.Add(new VSE.Point(r.Next(0, 10), r.Next(0, 10), 0));

            /*foreach (Point3d p in points)
                crvPoints.Add(new VSE.Point(p.X, p.Y, p.Z));*/

            VSE.RoadSegment rs = new VSE.RoadSegment();
            double speed = 0;
            DA.GetData(1, ref speed);
            rs.ConstructSegment(speed, crvPoints);

            Message = rs.RoadSegmentID.ToString();

            DA.SetData(0, rs);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("29dea128-b868-41c9-afef-f6c9ff02fcb9"); }
        }
    }
}