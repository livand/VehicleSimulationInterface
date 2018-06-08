using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using VehicleSimulationEngine;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace VehicleSimulationInterface
{
    public class VehicleSimulationInterfaceComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public VehicleSimulationInterfaceComponent()
          : base("VehicleSimulationInterface", "Nickname",
              "Description",
              "BH_Vehicle", "")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Number", "N", "First number to calculate", GH_ParamAccess.list);
            pManager.AddNumberParameter("Number", "N2", "Second number to calculate", GH_ParamAccess.item);           
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Output", "O", "Result of calculation", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<double> Numbers = new List<double>();
            DA.GetDataList(0, Numbers);
            double num = 0;
            DA.GetData(1, ref num);
            CalculationEngine ce = new CalculationEngine();
            ce.InitialList = Numbers;
            ce.Addition = num;
            ce.Calculate();
            DA.SetDataList(0, ce.Results);            

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
            get { return new Guid("506c62e6-b5bc-4c27-a3b4-826fc7968ddb"); }
        }
    }
}
