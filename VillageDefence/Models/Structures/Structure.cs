using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Structures
{
    public class Structure : BaseStructure
    {
        public override bool Upgrade()
        {
            return false;
        }
        public override bool CanUpgrade()
        {
            return false;
        }
        public override bool FuncA(Village myVillage)
        {
            return false;
        }
        public override bool FuncB(Village myVillage)
        {
            return false;
        }
        public override bool FuncC(Village myVillage)
        {
            return false;
        }
        public override bool FuncD(Village myVillage)
        {
            return false;
        }
        public override bool FuncE(Village myVillage)
        {
            return false;
        }
        public override bool FuncF(Village myVillage)
        {
            return false;
        }
        public override string CreateTextFuncA(Village myVillage)
        {
            return " ";
        }
        public override string CreateTextFuncB(Village myVillage)
        {
            return " ";
        }
        public override string CreateTextFuncC(Village myVillage)
        {
            return " ";
        }
        public override string CreateTextFuncD(Village myVillage)
        {
            return " ";
        }
        public override string CreateTextFuncE(Village myVillage)
        {
            return " ";
        }
        public override string CreateTextFuncF(Village myVillage)
        {
            return " ";
        }
        public override string CreateLabelA()
        {
            return " ";
        }
        public override string CreateLabelAValue(Village myVillage)
        {
            return " ";
        }
        public override string CreateLabelB()
        {
            return "";
        }
        public override string CreateLabelBValue(Village myVillage)
        {
            return "";
        }
        public override string CreateLabelC()
        {
            return "";
        }
        public override string CreateLabelCValue()
        {
            return "";
        }
        public override string CreateLabelD()
        {
            return "";
        }
        public override string CreateLabelDValue()
        {
            return " ";
        }
        public override bool DoDamage(int Damage, ref int DamageDone, ref int DamageBlocked, DefenseStructure GateA, DefenseStructure GateB)
        {
            Debug.Assert(false, "Should not call base structure Do Damage");
            return false;
        }
        public override String GetButtonLabel()
        {
            return " ";
        }
        public override void SetInitDetails()
        {

        }
    }
}
