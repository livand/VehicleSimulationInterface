using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using VSE = VehicleSimulationEngine;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.
namespace RoadProperties
{
    public class RoadPropertiesComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public RoadPropertiesComponent()
          : base("RoadProperties", "RoadProp",
              "Description",
              "BH_Vehicle", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "C", "Curve segment", GH_ParamAccess.item);
            pManager.AddNumberParameter("CurveSpeed", "CS", "Max speed for curve segment", GH_ParamAccess.item);
            pManager.AddNumberParameter("Tolerance", "T", "Distance between division points", GH_ParamAccess.item);
            pManager.AddPointParameter("RoadPoints", "RP", "Pre-divided list of curve points", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Point3d> crvPoints = new List<Point3d>();
            DA.GetDataList(3, crvPoints);
            double crvSpeed = 0;
            DA.GetData(1, ref crvSpeed);

            List<VSE.Point> vsePnts = new List<VSE.Point>();
            foreach (Point3d p in crvPoints)
                vsePnts.Add(new VSE.Point(p.X, p.Y, p.Z));

            VSE.Speed sp = new VSE.Speed();
            sp.PointList = vsePnts;
            sp.CrvSpeed = crvSpeed;
            //DA.SetDataTree(0, sp.RoadProp);

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("f114c3a1-255b-4b6e-8a77-404c3210171c"); }
        }
    }
}
