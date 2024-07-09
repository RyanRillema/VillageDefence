using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Units
{
    public abstract class Unit()
    {
        public string Name = "";
        public int Level = 0;
        public int Count = 0;
        public int CoinCost = 0;
        public int FoodCost = 0;
        public Combat CombatStats = new Combat();
        public HealthBar Health = new HealthBar(5);

        public abstract void SetInitDetails();
        
        public bool DoDamage(int Damage)
        {
            int TotalHealth = ((Count - 1) * Health.TotalHealth) + Health.CurrentHealth;
            if (TotalHealth > Damage)
            {
                if (Health.CurrentHealth < Damage)
                {
                    Damage -= Health.CurrentHealth;
                    Count--;
                }
                int DamageWhole = Damage / Health.TotalHealth;
                Count -= DamageWhole;
                Damage -= (DamageWhole * Health.TotalHealth);
                Health.CurrentHealth = Health.TotalHealth - Damage;
                return true;
            }
            else
            {
                Count = 0;
                return false;
            }
        }
    }
}
