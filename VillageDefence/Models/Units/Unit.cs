using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;
using VillageDefence.Models.Structures;

namespace VillageDefence.Models.Units
{
    public abstract class Unit : BaseUnit
    {
        public override bool DoDamage(int Damage, ref int DamageDone, ref int DamageBlocked, int TotalArmour)
        {
            // Return TRUE if unit count reaches 0
            Debug.Assert(Count > 0, "Cannot call damage on unit with 0 count");

            DamageDone = 0;

            while (Damage > 0)
            {
                if (Health.CurrentHealth + TotalArmour > Damage)
                {
                    Health.CurrentHealth -= Math.Max(Damage - TotalArmour, 0); // Do not allow negative damage
                    DamageDone += Math.Max(Damage - TotalArmour, 0);
                    //Blocked should be armour total unless the damage is less than the armour
                    DamageBlocked += Math.Min(TotalArmour, Damage);
                    Damage = 0;
                }
                else
                {
                    // Reduce damage by health and armour
                    Damage -= Health.CurrentHealth + TotalArmour;
                    // Damage done is only to health
                    DamageDone += Health.CurrentHealth;
                    DamageBlocked += TotalArmour;
                    Health.CurrentHealth = Health.TotalHealth;
                    Count--;
                }

                Debug.Assert(Health.CurrentHealth <= Health.TotalHealth, "Current health should't be greater than total health");

                if (Count == 0)
                {
                    return true;
                }
            }

            return false;
        }
        public override String GetButtonLabel()
        {
            String ReturnString;
            if (Level > 0)
            {
                ReturnString = Name + "\nDamage: " + CombatStats.DamageValue + "\nArmour: " + CombatStats.ArmourValue
                + "\nCount: " + Count + "\nHealth: " + Health.CurrentHealth + " / " + Health.TotalHealth;
            }
            else
            {
                ReturnString = Name;
            }

            return ReturnString;
        }
        public override void SetInitDetails()
        {

        }
    }
}
