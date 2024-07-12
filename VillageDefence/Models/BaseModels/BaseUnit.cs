using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.Units;

namespace VillageDefence.Models.BaseModels
{
    public abstract class BaseUnit : BaseModel
    {
        public int CoinCost = 0;
        public int FoodCost = 0;

    }

}
