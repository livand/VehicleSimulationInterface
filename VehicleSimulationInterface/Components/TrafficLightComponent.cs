using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace VehicleSimulationInterface.Components
{
    public class TrafficLightComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the TrafficLight class.
        /// </summary>
        public TrafficLightComponent()
          : base("TrafficLight", "TL",
              "Assemble traffic light information",
              "BH_Vehicle", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Location Point", "pt", "Point on curve for position of traffic light", GH_ParamAccess.item);
            pManager.AddGenericParameter("Timing Component", "t", "Traffic light cycle", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Traffic light", "TL", "Assembled traffic light", GH_ParamAccess.list); //Number parameter?
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d location = new Point3d();
            DA.SetData(0, location);


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
            get { return new Guid("c4027ae0-03d8-47ae-bccb-3325adc28f41"); }
        }
    }
}