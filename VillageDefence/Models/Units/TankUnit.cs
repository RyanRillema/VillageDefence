using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VillageDefence.Models.Units
{
    public class TankUnit() : Unit
    {
        public override void SetInitDetails()
        {
            Name = "Tank";
            CoinCost = 10;
            FoodCost = 8;
            Level = 1;
            Health.SetHealth(12);
            CombatStats.DamageType = 1;
            CombatStats.DamageValue = 1;
            CombatStats.ArmourType = 1;
            CombatStats.ArmourValue = 2;
        }
    }
}
