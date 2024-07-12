using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Structures
{
    public class ResourceStructure(int NewType) : Structure
    {
        // Type: 1-Coins, 2-Food
        public int Type = NewType;
        public int ResourceInc = 0;

        public override bool Upgrade()
        {
            return SetRawData(Type, Level + 1);
        }
        public override String CreateLabelA()
        {
            switch (Type)
            {
                case 1:                     
                    return StringReturnCheckLevel("Coins/turn:");
                case 2:
                    return StringReturnCheckLevel("Food/turn:");

                default:
                    return "";
            }
        }
        public override String CreateLabelAValue(Village myVillage)
        {
            return StringReturnCheckLevel(ResourceInc.ToString());
        }
        public override String GetButtonLabel()
        {
            String ReturnString;
            String TypeLabel;
            if (Level > 0)
            {
                if (Type == 1)
                {
                    TypeLabel = "Coins";
                }
                else
                {
                    TypeLabel = "Food";
                }
                ReturnString = Name + "\nLevel: " + Level + "\n" + TypeLabel + ": " + ResourceInc;
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
                    // Coins                    
                    return SetRawDataCoins(RawLevel);
                case 2:
                    // Food
                    return SetRawDataFood(RawLevel);
                default:
                    Name = "None";
                    return false;
            }
        }
        private bool SetRawDataCoins(int RawLevel)
        {
            switch (RawLevel)
            {
                case 0:
                    Name = "Rocks";
                    UpgradeCost = 10;
                    return true;
                case 1:
                    Name = "Shiny rocks";
                    UpgradeCost = 30;
                    ResourceInc = 1;
                    return true;
                case 2:
                    Name = "Bronze scratch";
                    UpgradeCost = 70;
                    ResourceInc = 3;
                    return true;
                case 3:
                    Name = "Bronze rock";
                    UpgradeCost = 100;
                    ResourceInc = 7;
                    return true;
                case 4:
                    Name = "Bronze mine";
                    UpgradeCost = 150;
                    ResourceInc = 10;
                    return true;
                case 5:
                    Name = "Silver scratch";
                    UpgradeCost = 200;
                    ResourceInc = 15;
                    return true;
                case 6:
                    Name = "Silver rock";
                    UpgradeCost = 250;
                    ResourceInc = 20;
                    return true;
                case 7:
                    Name = "Silver Mine";
                    UpgradeCost = 999;
                    ResourceInc = 25;
                    return true;
                default:
                    return false;
            }
        }
        private bool SetRawDataFood(int RawLevel)
        {
            switch (RawLevel)
            {
                case 0:
                    Name = "Soil";
                    UpgradeCost = 10;
                    ResourceInc = 0;
                    return true;
                case 1:
                    Name = "Shrubs";
                    UpgradeCost = 30;
                    ResourceInc = 1;
                    return true;
                case 2:
                    Name = "Big shrubs";
                    UpgradeCost = 70;
                    ResourceInc = 2;
                    return true;
                case 3:
                    Name = "Small crops";
                    UpgradeCost = 100;
                    ResourceInc = 5;
                    return true;
                case 4:
                    Name = "Medium crops";
                    UpgradeCost = 150;
                    ResourceInc = 8;
                    return true;
                case 5:
                    Name = "Large crops";
                    UpgradeCost = 999;
                    ResourceInc = 12;
                    return true;
                default:
                    return false;
            }
        }
    }

}
