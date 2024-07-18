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
        // Type: 1-Barracks, 2-Archery Range, 3-Forge
        public int Type = NewType;
        public int UpgradeArmourCost, UpgradeDamageCost;
        public bool UpgradeArmour, UpgradeDamage;
        public override bool Upgrade()
        {
            return SetRawData(Type, Level + 1);
        }
        public override bool CanUpgrade()
        {
            if ((UpgradeCost != 999) && (UpgradeArmour) && (UpgradeDamage))
            {
                return true;
            }
            return false;
        }
        public override bool FuncA(Village myVillage)
        {
            // Buy a unit
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
                case 3:
                    if ((myVillage.TankUnits.CoinCost <= myVillage.Coins) && (myVillage.TankUnits.FoodCost <= myVillage.Food))
                    {
                        myVillage.Coins -= myVillage.TankUnits.CoinCost;
                        myVillage.Food -= myVillage.TankUnits.FoodCost;
                        myVillage.TankUnits.Count++;
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
                case 3:
                    return StringReturnCheckLevel("Train Tank");
                default:
                    return " ";
            }
        }
        public override bool FuncB(Village myVillage)
        {
            // Buy a unit
            switch (Type)
            {
                case 1:
                    if ((myVillage.MeleeUnits.CoinCost * 10 <= myVillage.Coins) && (myVillage.MeleeUnits.FoodCost * 10 <= myVillage.Food))
                    {
                        myVillage.Coins -= myVillage.MeleeUnits.CoinCost * 10;
                        myVillage.Food -= myVillage.MeleeUnits.FoodCost * 10;
                        myVillage.MeleeUnits.Count += 10;
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case 2:
                    if ((myVillage.RangeUnits.CoinCost * 10 <= myVillage.Coins) && (myVillage.RangeUnits.FoodCost * 10 <= myVillage.Food))
                    {
                        myVillage.Coins -= myVillage.RangeUnits.CoinCost * 10;
                        myVillage.Food -= myVillage.RangeUnits.FoodCost * 10;
                        myVillage.RangeUnits.Count+=10;
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case 3:
                    if ((myVillage.TankUnits.CoinCost * 10 <= myVillage.Coins) && (myVillage.TankUnits.FoodCost * 10 <= myVillage.Food))
                    {
                        myVillage.Coins -= myVillage.TankUnits.CoinCost * 10;
                        myVillage.Food -= myVillage.TankUnits.FoodCost * 10;
                        myVillage.TankUnits.Count += 10;
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
        public override String CreateTextFuncB(Village myVillage)
        {
            switch (Type)
            {
                case 1:
                    return StringReturnCheckLevel("10 Melee");
                case 2:
                    return StringReturnCheckLevel("10 Range");
                case 3:
                    return StringReturnCheckLevel("10 Tank");
                default:
                    return " ";
            }
        }
        public override bool FuncC(Village myVillage)
        {
            // Upgrade Armour
            switch (Type)
            {
                case 1:
                    if ((!UpgradeArmour) && (UpgradeArmourCost > 0))
                    {
                        myVillage.MeleeUnits.CombatStats.ArmourValue++;
                        UpgradeArmour = true;
                        myVillage.Coins -= UpgradeArmourCost;

                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case 2:
                    if ((!UpgradeArmour) && (UpgradeArmourCost > 0))
                    {
                        myVillage.RangeUnits.CombatStats.ArmourValue++;
                        UpgradeArmour = true;
                        myVillage.Coins -= UpgradeArmourCost;

                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case 3:
                    if ((!UpgradeArmour) && (UpgradeArmourCost > 0))
                    {
                        myVillage.TankUnits.CombatStats.ArmourValue++;
                        UpgradeArmour = true;
                        myVillage.Coins -= UpgradeArmourCost;

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
        public override string CreateTextFuncC(Village myVillage)
        {
            String ReturnString = " ";
            if ((!UpgradeArmour) && (UpgradeArmourCost > 0))
            {
                ReturnString = "+1 Armour";
            }
            return ReturnString;
        }
        public override bool FuncD(Village myVillage)
        {
            // Upgrade damage
            switch (Type)
            {
                case 1:
                    if ((!UpgradeDamage) && (UpgradeDamageCost > 0))
                    {
                        myVillage.MeleeUnits.CombatStats.DamageValue++;
                        UpgradeDamage = true;
                        myVillage.Coins -= UpgradeDamageCost;

                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case 2:
                    if ((!UpgradeDamage) && (UpgradeDamageCost > 0))
                    {
                        myVillage.RangeUnits.CombatStats.DamageValue++;
                        UpgradeDamage = true;
                        myVillage.Coins -= UpgradeDamageCost;

                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case 3:
                    if ((!UpgradeDamage) && (UpgradeDamageCost > 0))
                    {
                        myVillage.TankUnits.CombatStats.DamageValue++;
                        UpgradeDamage = true;
                        myVillage.Coins -= UpgradeDamageCost;

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
        public override string CreateTextFuncD(Village myVillage)
        {
            String ReturnString = " ";
            if ((!UpgradeDamage) && (UpgradeDamageCost > 0))
            {
                ReturnString = "+1 Damage";
            }
            return ReturnString;
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
                case 3:
                    if (Level > 0)
                    {
                        return StringReturnCheckLevel("Tank");
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
                case 3:
                    return StringReturnCheckLevel("Coins: " + myVillage.TankUnits.CoinCost.ToString());
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
                case 3:
                    return StringReturnCheckLevel("Food: " + myVillage.TankUnits.FoodCost.ToString());
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
                case 3:
                    return SetRawForge(RawLevel);
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
                    UpgradeArmour = true;
                    UpgradeDamage = true;
                    return true;
                case 1:
                    Name = "Spear circle";
                    Count = 1;
                    UpgradeCost = 30;
                    return true;
                case 2:
                    Name = "Spear hut";
                    Count = 1;
                    UpgradeArmourCost = 20;
                    UpgradeDamageCost = 20;
                    UpgradeCost = 50;
                    UpgradeArmour = false;
                    UpgradeDamage = false;
                    return true;
                case 3:
                    Name = "Spear hall";
                    Count = 1;
                    UpgradeArmourCost = 50;
                    UpgradeDamageCost = 50;
                    UpgradeArmour = false;
                    UpgradeDamage = false;
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
                    UpgradeArmour = true;
                    UpgradeDamage = true;
                    return true;
                case 1:
                    Name = "Bow stack";
                    Count = 1;
                    UpgradeCost = 50;
                    return true;
                case 2:
                    Name = "Bow target";
                    Count = 1;
                    UpgradeArmourCost = 30;
                    UpgradeDamageCost = 30;
                    UpgradeArmour = false;
                    UpgradeDamage = false;
                    UpgradeCost = 100;
                    return true;
                case 3:
                    Name = "Bow range";
                    Count = 1;
                    UpgradeArmourCost = 70;
                    UpgradeDamageCost = 70;
                    UpgradeArmour = false;
                    UpgradeDamage = false;
                    UpgradeCost = 999;
                    return true;
                default:
                    return false;
            }
        }
        private bool SetRawForge(int RawLevel)
        {
            switch (RawLevel)
            {
                case 0:
                    Name = "Build site";
                    UpgradeCost = 40;
                    UpgradeArmour = true;
                    UpgradeDamage = true;
                    return true;
                case 1:
                    Name = "Anvil";
                    Count = 1;
                    UpgradeCost = 50;
                    return true;
                case 2:
                    Name = "Workbench";
                    Count = 1;
                    UpgradeArmourCost = 35;
                    UpgradeDamageCost = 35;
                    UpgradeCost = 60;
                    UpgradeArmour = false;
                    UpgradeDamage = false;
                    return true;
                case 3:
                    Name = "Forge";
                    Count = 1;
                    UpgradeArmourCost = 80;
                    UpgradeDamageCost = 80;
                    UpgradeArmour = false;
                    UpgradeDamage = false;
                    UpgradeCost = 999;
                    return true;
                default:
                    return false;
            }
        }
    }
}
