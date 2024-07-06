﻿using System;
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
            CoinCost = 8;
            FoodCost = 5;
        }
    }
}