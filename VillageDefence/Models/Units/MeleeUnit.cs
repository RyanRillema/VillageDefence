using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models.Units
{
    public class MeleeUnit() : BaseUnit
    {
        public override void SetInitDetails()
        {
            Name = "Melee";
            CoinCost = 5;
            FoodCost = 5;
            CombatStats.DamageType = 1;
            CombatStats.DamageValue = 3;
            CombatStats.ArmourType = 1;
            CombatStats.ArmourValue = 1;
        }
    }
}
