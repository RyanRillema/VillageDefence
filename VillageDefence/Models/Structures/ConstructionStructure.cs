using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models.Structures
{
    public class ConstructionStructure : Structure
    {
        // Type: 1-Barracks
        public int Type = 0;

        public override bool Upgrade()
        {
            return true;    
        }
        public override String CreateLabelA()
        {
            return "";
        }
        public override String CreateLabelAValue()
        {
            return "";
        }
        public override String CreateLabelB()
        {
            return "";
        }
        public override String CreateLabelBValue()
        {
            return "";
        }
        public override String CreateLabelC()
        {
            return "";
        }
        public override String CreateLabelCValue()
        {
            return "";
        }
        public override String CreateLabelD()
        {
            return "";
        }
        public override String CreateLabelDValue()
        {
            return "";
        }
    }
}
