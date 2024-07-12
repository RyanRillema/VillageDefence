using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;

namespace VillageDefence.Models.Units
{
    public abstract class Unit : BaseUnit
    {
        public override bool DoDamage(int Damage, ref int DamageDone)
        {
            // Return TRUE if unit count reaches 0

            Debug.Assert(Count > 0, "Cannot call damage on unit with 0 count");

            DamageDone = 0;

            while (Damage > 0)
            {
                if (Health.CurrentHealth + CombatStats.ArmourValue > Damage)
                {
                    Health.CurrentHealth -= Damage - CombatStats.ArmourValue;
                    DamageDone += Damage - CombatStats.ArmourValue;
                    Damage = 0;
                }
                else
                {
                    // Reduce damage by health and armour
                    Damage -= Health.CurrentHealth + CombatStats.ArmourValue;
                    // Damage done is only to health
                    DamageDone += Health.CurrentHealth;
                    Health.CurrentHealth = Health.TotalHealth;
                    Count--;
                }

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
