using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VillageDefence.Models.BaseModels
{
    public abstract class BaseStructure : BaseModel
    {
        public int UpgradeCost = 0;

        public abstract bool Upgrade();
        public abstract bool FuncA(Village myVillage);
        public abstract bool FuncB(Village myVillage);
        public abstract string CreateTextFuncA(Village myVillage);
        public abstract string CreateTextFuncB(Village myVillage);
        public abstract string CreateLabelA();
        public abstract string CreateLabelAValue(Village myVillage);
        public abstract string CreateLabelB();
        public abstract string CreateLabelBValue(Village myVillage);
        public abstract string CreateLabelC();
        public abstract string CreateLabelCValue();
        public abstract string CreateLabelD();
        public abstract string CreateLabelDValue();
    }

}
