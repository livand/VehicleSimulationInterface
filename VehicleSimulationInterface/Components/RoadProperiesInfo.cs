using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace RoadProperties
{
    public class RoadPropertiesInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "RoadProperties";
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
                return new Guid("4528ca05-c864-4a58-83fe-8cac95f3cd06");
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
