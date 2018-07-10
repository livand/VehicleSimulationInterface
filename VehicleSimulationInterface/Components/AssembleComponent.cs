using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using VSE = VehicleSimulationEngine;

namespace VehicleSimulationInterface.Components
{
    public class AssembleComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the AssembleComponent class.
        /// </summary>
        public AssembleComponent()
          : base("AssembleComponent", "Ass",
              "Assemble the information for each road to construct a simulation",
              "BH_Vehicle", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Segments", "s", "Segments for road construction", GH_ParamAccess.list);
            pManager.AddNumberParameter("Distribution", "d", "Distribution of vehicles", GH_ParamAccess.item); //Parameter type?
            pManager.AddNumberParameter("Time", "t", "Start time of vehicles", GH_ParamAccess.item); //Parameter type?
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Assemble", "a", "Assembled road information", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<VSE.RoadSegment> rs = new List<VSE.RoadSegment>();

            List<Grasshopper.Kernel.Types.GH_ObjectWrapper> wrap = new List<Grasshopper.Kernel.Types.GH_ObjectWrapper>();
            DA.GetDataList(0, wrap);
            foreach(Grasshopper.Kernel.Types.GH_ObjectWrapper w in wrap)
                rs.Add(w.Value as VSE.RoadSegment);

            if (rs.Count == 0) return; //Protection on bad input not being correctly read as a RoadSegment object

            Message = rs[0].RoadSegmentID.ToString();
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
            get { return new Guid("657d96c2-8734-4e41-8d6c-26fd03b6a8f6"); }
        }
    }
}