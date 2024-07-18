using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.Structures;

namespace VillageDefence.Models.BaseModels
{
    public abstract class BaseModel
    {
        public string Name = "";
        public int Level = 0;
        public int Count = 0;
        public Combat CombatStats = new Combat();
        public HealthBar Health = new HealthBar();

        public void HealUnit(int iHealth = 1)
        {
            if (Health.CurrentHealth + iHealth < Health.TotalHealth)
            {
                Health.CurrentHealth = Health.CurrentHealth + iHealth;
            }
            else
            {
                Health.CurrentHealth = Health.TotalHealth;
            }
        }
        public String StringReturnCheckLevel(String StringReturn)
        {
            if (Level < 1)
            {
                return " ";
            }
            else
            {
                return StringReturn;
            }
        }
        public abstract bool DoDamage(int Damage, ref int DamageDone, ref int DamageBlocked, int TotalArmour);
        public abstract String GetButtonLabel();
        public abstract void SetInitDetails();
    }
}
