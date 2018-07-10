using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace VehicleSimulationInterface.Components
{
    public class LaunchComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the LaunchComponent class.
        /// </summary>
        public LaunchComponent()
          : base("LaunchComponent", "Launch",
              "Launch simulation",
              "BH_Vehicle", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("PtDist", "ptDist", "Tolerance distance between segment points [m]", GH_ParamAccess.item, 0.1);
            pManager.AddNumberParameter("TimeStep", "timeStep", "Time step size [s]", GH_ParamAccess.item, 1.0);
            pManager.AddGenericParameter("Assembly", "assembly", "Assembled data for each road", GH_ParamAccess.list);
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
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
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
            get { return new Guid("4ea02449-552d-4b44-bd6f-59930c9b509b"); }
        }
    }
}