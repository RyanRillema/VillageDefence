using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VillageDefence.Models.Structures
{
    public class BaseStructure : Structure
    {
        public override bool Upgrade()
        {
            return false;
        }
        public override bool FuncA()
        {
            return false;
        }
        public override bool FuncB()
        {
            return false;
        }
        public override String CreateLabelA()
        {
           return " ";
        }
        public override String CreateLabelAValue()
        {
            return " ";
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
            return " ";
        }
        public override String CreateTextFuncA()
        {
            return " ";
        }
        public override String CreateTextFuncB()
        {
            return " ";
        }
    }
}
