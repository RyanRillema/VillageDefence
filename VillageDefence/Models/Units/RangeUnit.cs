using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models.Units
{
    public class RangeUnit : Unit
    {

        public override void SetInitDetails()
        {
            Name = "Range";
            CoinCost = 8;
            FoodCost = 5;
            Level = 1;
            CombatStats.DamageType = 2;
            CombatStats.DamageValue = 5;
            CombatStats.ArmourType = 1;
            CombatStats.ArmourValue = 0;
        }
    }
}
