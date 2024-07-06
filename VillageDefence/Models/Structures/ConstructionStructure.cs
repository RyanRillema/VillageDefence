using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;
using VillageDefence.Models.Units;

namespace VillageDefence.Models.Structures
{
    public class ConstructionStructure(int NewType) : BaseStructure
    {
        // private Unit myUnit= new Unit();
        // Type: 1-Barracks
        public int Type = NewType;

        public override bool Upgrade()
        {
            return SetRawData(Type, Level + 1);
        }        
        public override String CreateLabelA()
        {
            switch (Type)
            {
                case 1:
                    return "0";
                default:
                    return " ";
            }
        }
        public override String CreateLabelAValue()
        {
            switch (Type)
            {
                case 1:
                    return " ";
                default:
                    return " ";
            }
        }
        public override String CreateTextFuncA()
        {
            switch (Type)
            {
                case 1:
                    return "Train Melee";
                default:
                    return " ";
            }
        }
        private bool SetRawData(int RawType, int RawLevel)
        {
            Type = RawType;
            Level = RawLevel;

            switch (RawType)
            {
                case 1:
                    // Tower
                    return SetRawBarracks(RawLevel);                
                default:
                    Name = "None";
                    return false;
            }
        }
        private bool SetRawBarracks(int RawLevel)
        {
            switch (RawLevel)
            {
                case 0:
                    Name = "Dirt";
                    UpgradeCost = 20;
                    return true;
                case 1:
                    Name = "Barracks";
                    UpgradeCost = 999;
                    return true;
                default:
                    return false;
            }
        }

    }
}
