using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Units
{
    public class MeleeUnit() : Unit
    {
        public override void SetInitDetails()
        {
            Name = "Melee";
            CoinCost = 5;
            FoodCost = 5;
            Level = 1;
            CombatStats.DamageType = 1;
            CombatStats.DamageValue = 3;
            CombatStats.ArmourType = 1;
            CombatStats.ArmourValue = 1;
        }
    }
}
