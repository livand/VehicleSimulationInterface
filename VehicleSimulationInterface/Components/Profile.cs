using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using VSE = VehicleSimulationEngine;

namespace VehicleSimulationInterface.Components
{
    public class Profile : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Profiles class.
        /// </summary>
        public Profile()
          : base("Profile", "Profile",
              "Assemble Vehicle information",
              "BH_Vehicle", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "name", "Profile name", GH_ParamAccess.item);
            pManager.AddNumberParameter("Length", "length", "Vehicle length", GH_ParamAccess.item, 5.0); //Parameter type?
            pManager.AddNumberParameter("Width", "width", "Vehicle width", GH_ParamAccess.item, 1.8); //Parameter type?
            pManager.AddNumberParameter("FrontToAx", "frontToAx", "Distance from front of vehicle to front axis", GH_ParamAccess.item, 1.0); //Parameter type?
            pManager.AddNumberParameter("BackToAx", "backToAx", "Distance from back of vehicle to back axis", GH_ParamAccess.item, 1.0); //Parameter type?
            pManager.AddNumberParameter("StopMargin", "stopMargin", "Margin to next object when stopped", GH_ParamAccess.item, 2.0);
            pManager.AddNumberParameter("MaxSpeed", "maxSpeed", "Top speed for vehicle", GH_ParamAccess.item, 120.0);
            pManager.AddNumberParameter("MaxAcc", "maxAcc", "Max acceleration for vehicle", GH_ParamAccess.item, 3.0);
            pManager.AddNumberParameter("MaxBrake", "maxBrake", "Max deceleration for vehicle", GH_ParamAccess.item, 7.5);
            
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Profile", "p", "Vehicle profile", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "";
            double length = 0;
            double width = 0;
            double frontToAx = 0;
            double backToAx = 0;
            double stopMargin = 0;
            double maxSpeed = 0;
            double maxAcc = 0;
            double maxBrake = 0;
            
            DA.GetData(0, ref name);
            DA.GetData(1, ref length);
            DA.GetData(2, ref width);
            DA.GetData(3, ref frontToAx);
            DA.GetData(4, ref backToAx);
            DA.GetData(5, ref stopMargin);
            DA.GetData(6, ref maxSpeed);
            DA.GetData(7, ref maxAcc);
            DA.GetData(8, ref maxBrake);

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
            get { return new Guid("acae1242-97de-4e55-8585-3bd9d55bafc9"); }
        }
    }
}