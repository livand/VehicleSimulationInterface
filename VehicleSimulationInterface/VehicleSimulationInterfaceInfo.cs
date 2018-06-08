using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace VehicleSimulationInterface
{
    public class VehicleSimulationInterfaceInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "VehicleSimulationInterface";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("038c470a-c210-4c12-8959-b6daf97a7583");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
