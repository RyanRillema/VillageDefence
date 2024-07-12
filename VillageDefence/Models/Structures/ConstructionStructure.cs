using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;
using VillageDefence.Models.Units;

namespace VillageDefence.Models.Structures
{
    public class ConstructionStructure(int NewType) : Structure
    {
        // private Unit myUnit= new Unit();
        // Type: 1-Barracks, 2-Archery Range
        public int Type = NewType;
        public override bool Upgrade()
        {
            return SetRawData(Type, Level + 1);
        }
        public override bool FuncA(Village myVillage)
        {
            switch (Type)
            {
                case 1:
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
                case 2:
                    if ((myVillage.RangeUnits.CoinCost <= myVillage.Coins) && (myVillage.RangeUnits.FoodCost <= myVillage.Food))
                    {
                        myVillage.Coins -= myVillage.RangeUnits.CoinCost;
                        myVillage.Food -= myVillage.RangeUnits.FoodCost;
                        myVillage.RangeUnits.Count++;
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return false;
            }            
        }
        public override String CreateTextFuncA(Village myVillage)
        {
            switch (Type)
            {
                case 1:                    
                    return StringReturnCheckLevel("Train Melee");
                case 2:
                    return StringReturnCheckLevel("Train Range");
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
                        return StringReturnCheckLevel("Melee");
                    }
                    else
                    {
                        return " ";
                    }                    
                case 2:
                    if (Level > 0)
                    {
                        return StringReturnCheckLevel("Range");
                    }
                    else
                    {
                        return " ";
                    }
                default:
                    return " ";
            }
        }
        public override String CreateLabelAValue(Village myVillage)
        {
            switch (Type)
            {
                case 1:
                    return StringReturnCheckLevel("Coins: " + myVillage.MeleeUnits.CoinCost.ToString());
                case 2:
                    return StringReturnCheckLevel("Coins: " + myVillage.RangeUnits.CoinCost.ToString());
                default:
                    return " ";
            }
        }
        public override String CreateLabelBValue(Village myVillage)
        {
            switch (Type)
            {
                case 1:
                    return StringReturnCheckLevel("Food: " + myVillage.MeleeUnits.FoodCost.ToString());
                case 2:
                    return StringReturnCheckLevel("Food: " + myVillage.RangeUnits.FoodCost.ToString());
                default:
                    return " ";
            }
        }
        public override String GetButtonLabel()
        {
            String ReturnString;
            if (Level > 0)
            {
                ReturnString = Name + "\nLevel: " + Level;
            }
            else
            {
                ReturnString = Name;
            }

            return ReturnString;
        }
        public override void SetInitDetails()
        {
            SetRawData(Type, Level);
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
                case 2:
                    return SetRawArchery(RawLevel);
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
                    Name = "Build site";
                    UpgradeCost = 20;
                    return true;
                case 1:
                    Name = "Barracks";
                    Count = 1;
                    UpgradeCost = 999;
                    return true;
                default:
                    return false;
            }
        }
        private bool SetRawArchery(int RawLevel)
        {
            switch (RawLevel)
            {
                case 0:
                    Name = "Build site";
                    UpgradeCost = 40;
                    return true;
                case 1:
                    Name = "ArcherRange";
                    Count = 1;
                    UpgradeCost = 999;
                    return true;
                default:
                    return false;
            }
        }

    }
}
