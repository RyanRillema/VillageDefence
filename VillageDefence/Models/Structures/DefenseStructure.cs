using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Structures
{
    public class DefenseStructure(int NewType) : Structure
    {
        // Type: 1-Tower, 2-Gate
        public int Type = NewType;

        public override bool Upgrade()
        {
            return SetRawData(Type, Level + 1); 
        }        
        public override String CreateLabelA()
        {
            return StringReturnCheckLevel("Damage:");
        }
        public override String CreateLabelAValue(Village myVillage)
        {
            return StringReturnCheckLevel(CombatStats.DamageValue.ToString());
        }
        public override String CreateLabelB()
        {
            return StringReturnCheckLevel("Type");
        }
        public override String CreateLabelBValue(Village myVillage)
        {
            return StringReturnCheckLevel(CombatStats.DamageType.ToString());
        }
        public override String CreateLabelC()
        {
            return StringReturnCheckLevel("Armour");
        }
        public override String CreateLabelCValue()
        {
            return StringReturnCheckLevel(CombatStats.ArmourValue.ToString());
        }
        public override String CreateLabelD()
        {
            return StringReturnCheckLevel("Type");
        }
        public override String CreateLabelDValue()
        {
            return StringReturnCheckLevel(CombatStats.ArmourType.ToString());
        }
        public override String GetButtonLabel()
        {
            String ReturnString;
            if (Level > 0)
            {
                ReturnString = Name + "\nLevel: " + Level + "\nDamage: " + CombatStats.DamageValue + "\nArmour: " + CombatStats.ArmourValue
                    + "\nHP: " + Health.CurrentHealth + " / " + Health.TotalHealth;
            } else
            {
                ReturnString = Name;
            }

            return ReturnString;
        }
        public override bool DoDamage(int Damage, ref int DamageDone)
        {
            // Return TRUE if unit count reaches 0

            Debug.Assert(Count > 0, "Cannot call damage on unit with 0 count");

            DamageDone = 0;

            while (Damage > 0)
            {
                if (Health.CurrentHealth + CombatStats.ArmourValue > Damage)
                {
                    Health.CurrentHealth -= Damage - CombatStats.ArmourValue;
                    DamageDone += Damage - CombatStats.ArmourValue;
                    Damage = 0;
                }
                else
                {
                    // Reduce damage by health and armour
                    Damage -= Health.CurrentHealth + CombatStats.ArmourValue;
                    // Damage done is only to health
                    DamageDone += Health.CurrentHealth;                    
                    if (--Count > 0)
                    {
                        Health.CurrentHealth = Health.TotalHealth;
                    }
                    else
                    {
                        Health.CurrentHealth = 0;
                        return true;
                    }
                }
            }

            return false;
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
                    return SetRawDataTower(RawLevel);
                case 2:
                    return SetRawDataWall(RawLevel);
                default:
                    Name = "None";
                    CombatStats.ArmourType = 0;
                    CombatStats.ArmourValue = 0;
                    CombatStats.DamageType = 0;
                    CombatStats.DamageValue = 0;
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
                    Count = 1;
                    Health.SetHealth(25);
                    CombatStats.ArmourType = 1;
                    CombatStats.ArmourValue = 0;
                    CombatStats.DamageType = 2;
                    CombatStats.DamageValue = 10;
                    return true;
                case 2:
                    Name = "Spear pile";
                    UpgradeCost = 100;
                    Health.SetHealth(50);
                    CombatStats.ArmourValue = 3;
                    CombatStats.DamageValue = 20;
                    return true;
                case 3:
                    Name = "Arrows";
                    UpgradeCost = 150;
                    Health.SetHealth(75);
                    CombatStats.ArmourValue = 8;
                    CombatStats.DamageValue = 30;
                    return true;
                case 4:
                    Name = "Flaming arrows";
                    UpgradeCost = 999;
                    Health.SetHealth(100);
                    CombatStats.ArmourValue = 8;
                    CombatStats.DamageValue = 40;
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
                    Count = 1;
                    CombatStats.ArmourType = 1;
                    CombatStats.ArmourValue = 3;
                    return true;
                case 2:
                    Name = "Medium stick gate";
                    UpgradeCost= 70;
                    CombatStats.ArmourValue = 8;
                    return true;
                case 3:
                    Name = "Thick stick gate";
                    UpgradeCost = 100;
                    CombatStats.ArmourValue = 20;
                    return true;
                case 4:
                    Name = "Woven stick gate";
                    UpgradeCost = 150;
                    CombatStats.ArmourValue = 25;
                    return true;
                default:
                    return false;
            }
        }

    }        
}
