using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models.BaseModels
{

    public class Combat
    {
        public int DamageValue = 0;
        public int DamageType = 0; // 1-Melee, 2-Range
        public int ArmourValue = 0; 
        public int ArmourType = 0; //Just 1 for now
    }

    public class HealthBar(int NewHealth)
    {
        public int TotalHealth = NewHealth;
        public int CurrentHealth = NewHealth;

    }

}
