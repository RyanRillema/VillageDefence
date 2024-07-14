using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence
{
    public static class SpinGenerator
    {
        public static bool SpinBattle()
        {
            //1 in 5 chance of battle
            Random rnd = new Random();
            int Value = rnd.Next(1, 6);
            if (Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool SpinAttackerAttack(int Chance = 2)
        {
            Random rnd = new Random();

            if (rnd.Next(1, Chance + 1) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void SetupAttack(int Turn, BaseModel AttackMelee, BaseModel AttackRange)
        {
            Random rnd = new Random();
            int Max;
            int Min;

            AttackMelee.SetInitDetails();
            AttackMelee.Name = "Slasher";
            AttackRange.SetInitDetails();
            AttackRange.Name = "Thrower";

            Max = (Turn / 5);
            Min = (Turn / 10) + 1;
            //Max must be greater or equal to min
            Max = Math.Max(Max, Min);
            AttackMelee.Count = rnd.Next(Min, Max + 1);

            Max = (Turn / 10);
            Min = (Turn / 20);
            Max = Math.Max(Max, Min);
            AttackRange.Count = rnd.Next(Min, Max + 1);

            for (int UpgradeChance = 0; UpgradeChance < (Turn / 30); UpgradeChance++)
            {
                SetupAttackUpgradeSpin( Turn, AttackMelee, AttackRange);
            }
        }
        private static void SetupAttackUpgradeSpin(int Turn, BaseModel AttackMelee, BaseModel AttackRange)
        {
            Random rnd = new Random();
            BaseModel AttackUpgrade;

            if (rnd.Next(1, 6) == 1)
            {
                if (rnd.Next(1,3) == 1)
                {
                    AttackUpgrade = AttackMelee;
                } else
                {
                    AttackUpgrade = AttackRange;
                }
                if (rnd.Next(1, 3) == 1)
                {
                    AttackUpgrade.CombatStats.DamageValue++;
                } else
                {
                    AttackUpgrade.CombatStats.ArmourValue++;
                }
            }

        }
    }
}
