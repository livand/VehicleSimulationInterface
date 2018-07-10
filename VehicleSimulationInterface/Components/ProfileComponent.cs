using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Grasshopper.Kernel;
using SMARTGrasshopperCustomInterface;

//using SmartProcessAnalysisEngine;


namespace SMARTMoveGH
{
    public class ProfileComponent
    {

        //inputs on the component

        private SMARTInputBoxString _pName;
        private SMARTInputBoxNumber _length;
        private SMARTInputBoxNumber _width;
        private SMARTInputBoxNumber _stopMargin;
        private SMARTInputBoxNumber _maxSpeed;
        private SMARTInputBoxNumber _maxAcc;
        private SMARTInputBoxNumber _maxBrake;
        //private SMARTInputBoxString _colour;
        //private SMARTColourSwatch _colourSwatch;


        /*public ProfileComponent()
                : base("Profile", "Profile", "Create a profile for the population", "SmartProcessAnalyser", "0 | Scenario")
        {

            /*_pName = new SMARTInputBoxString(this, "Male");
            _length = new SMARTInputBoxNumber(this, 5.0);
            _width = new SMARTInputBoxNumber(this, 2.5);
            _stopMargin = new SMARTInputBoxNumber(this, 2.0);
            _maxSpeed = new SMARTInputBoxNumber(this, 120.0);
            _maxAcc = new SMARTInputBoxNumber(this, 2.0);
            _maxBrake = new SMARTInputBoxNumber(this, 4.0);
            //_colour = new SMARTInputBoxString(this, "#ffffb4");
            //_colourSwatch = new SMARTColourSwatch(this, Color.CornflowerBlue);

            AddClickableItem(_pName);
            AddClickableItem(_height);
            AddClickableItem(_width);
            AddClickableItem(_walkSpeed);
            AddClickableItem(_speedVar);
            AddClickableItem(_speedUp);
            AddClickableItem(_speedDown);
            AddClickableItem(_colourSwatch);
            AddClickableItem(_keyString);
        }*/

    }
}