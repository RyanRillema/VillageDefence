using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models.Units
{
    public class MeleeUnit : BaseUnit
    {

        public override void SetInitDetails()
        {
            CoinCost = 5;
            FoodCost = 5;
        }
    }
}
