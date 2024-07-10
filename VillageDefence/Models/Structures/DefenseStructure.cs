using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Structures
{
    public class DefenseStructure(int NewType) : BaseStructure
    {
        // Type: 1-Tower, 2-Gate
        public int Type = NewType;
        public Combat Combat = new Combat();

        public override bool Upgrade()
        {
            return SetRawData(Type, Level + 1); 
        }        
        public override String CreateLabelA()
        {
            return "Damage:";
        }
        public override String CreateLabelAValue(Village myVillage)
        {
            return Combat.DamageValue.ToString();
        }
        public override String CreateLabelB()
        {
            return "Type";
        }
        public override String CreateLabelBValue(Village myVillage)
        {
            return Combat.DamageType.ToString();
        }
        public override String CreateLabelC()
        {
            return "Armour";
        }
        public override String CreateLabelCValue()
        {
            return Combat.ArmourValue.ToString();
        }
        public override String CreateLabelD()
        {
            return "Type";
        }
        public override String CreateLabelDValue()
        {
            return Combat.ArmourType.ToString();
        }
        private bool SetRawData(int RawType, int RawLevel)
        {
            Type = RawType;
            Level = RawLevel;
                      

            switch (RawType)
            {
                case 1:
                    // Tower
                    return SetRawDataTower(RawLevel);
                case 2:
                    return SetRawDataWall(RawLevel);
                default:
                    Name = "None";                  
                    Combat.ArmourType = 0;
                    Combat.ArmourValue = 0;
                    Combat.DamageType = 0;
                    Combat.DamageValue = 0;
                    return false;
            }
        }
        private bool SetRawDataTower(int RawLevel)
        {
            switch (RawLevel)
            {
                case 0:
                    Name = "Dirt";
                    UpgradeCost = 20;
                    return true;
                case 1:
                    Name = "Rock pile";
                    UpgradeCost = 50;
                    Combat.ArmourType = 1;
                    Combat.ArmourValue = 0;
                    Combat.DamageType = 2;
                    Combat.DamageValue = 4;
                    return true;
                case 2:
                    Name = "Spear pile";
                    UpgradeCost = 100;
                    Combat.ArmourValue = 3;
                    Combat.DamageValue = 8;
                    return true;
                case 3:
                    Name = "Arrows";
                    UpgradeCost = 150;
                    Combat.ArmourValue = 8; 
                    Combat.DamageValue = 15;
                    return true;
                case 4:
                    Name = "Flaming arrows";
                    UpgradeCost = 999;
                    Combat.ArmourValue = 8;
                    Combat.DamageValue = 22;
                    return true;
                default:
                    return false;
            }
        }

        private bool SetRawDataWall(int RawLevel)
        {
            switch (RawLevel)
            {
                case 0:
                    Name = "Dirt";
                    UpgradeCost = 10;
                    return true;
                case 1:
                    Name = "Simple stick gate";
                    UpgradeCost = 25;
                    Combat.ArmourType = 1;
                    Combat.ArmourValue = 3;
                    return true;
                case 2:
                    Name = "Medium stick gate";
                    UpgradeCost= 70;
                    Combat.ArmourValue = 8;
                    return true;
                case 3:
                    Name = "Thick stick gate";
                    UpgradeCost = 100;
                    Combat.ArmourValue = 20;
                    return true;
                case 4:
                    Name = "Woven stick gate";
                    UpgradeCost = 150;
                    Combat.ArmourValue = 25;
                    return true;
                default:
                    return false;
            }
        }

    }        
}
