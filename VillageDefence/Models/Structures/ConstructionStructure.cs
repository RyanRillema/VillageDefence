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
        public override bool FuncA(Village myVillage)
        {
            if ((myVillage.MeleeUnits.CoinCost <= myVillage.Coins) && (myVillage.MeleeUnits.FoodCost <= myVillage.Food))
            {
                myVillage.Coins -= myVillage.MeleeUnits.CoinCost;
                myVillage.Food -= myVillage.MeleeUnits.FoodCost;
                myVillage.MeleeUnits.Count++;
                return true;
            }
            else
            {
                return true;
            }
        }
        public override String CreateTextFuncA(Village myVillage)
        {
            switch (Type)
            {
                case 1:
                    if (Level > 0)
                    {
                        return "Train Melee";
                    }
                    else
                    {
                        return " ";
                    }
                default:
                    return " ";
            }
        }
        public override String CreateLabelA()
        {
            switch (Type)
            {
                case 1:
                    if (Level > 0)
                    {
                        return "Melee";
                    }
                    else
                    {
                        return " ";
                    }                    
                case 2:
                    return "Range";
                default:
                    return " ";
            }
        }
        public override String CreateLabelAValue(Village myVillage)
        {
            switch (Type)
            {
                case 1:
                    if (Level > 0)
                    {
                        return "Coins: " + myVillage.MeleeUnits.CoinCost.ToString();
                    }
                    else
                    {
                        return " ";
                    }
                default:
                    return " ";
            }
        }
        public override String CreateLabelBValue(Village myVillage)
        {
            switch (Type)
            {
                case 1:
                    if (Level > 1)
                    {
                        return "Food: " + myVillage.MeleeUnits.FoodCost.ToString();
                    }
                    else
                    {
                        return " ";
                    }                    
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
