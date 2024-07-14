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
            AttackMelee.Count = rnd.Next(Min, Max);

            Max = (Turn / 10);
            Min = (Turn / 20);
            Max = Math.Max(Max, Min);
            AttackRange.Count = rnd.Next(Min, Max);
        }
    }
}
