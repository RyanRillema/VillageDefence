using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Structures
{
    public abstract class Structure
    {
        public string Name = "Nothing";
        public int Level = -1;
        public int UpgradeCost = 0;
        public HealthBar Health = new HealthBar(100);

        public abstract bool Upgrade();
        public abstract bool FuncA(Village myVillage);
        public abstract bool FuncB(Village myVillage);
        public abstract String CreateTextFuncA(Village myVillage);
        public abstract String CreateTextFuncB(Village myVillage);
        public abstract String CreateLabelA();
        public abstract String CreateLabelAValue();
        public abstract String CreateLabelB();
        public abstract String CreateLabelBValue();
        public abstract String CreateLabelC();
        public abstract String CreateLabelCValue();
        public abstract String CreateLabelD();
        public abstract String CreateLabelDValue();        
    }
}
