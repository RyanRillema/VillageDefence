using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.Units;
using VillageDefence.Views;

namespace VillageDefence.Models
{
    public class Battle()
    {
        public BattleView myParent;
        public Village myVillage;
        public MeleeUnit AttackMelee = new MeleeUnit();
        public RangeUnit AttackRange = new RangeUnit();
        public MeleeUnit MyMelee;
        public RangeUnit MyRange;

        public void SetupBattle(Village SetVillage, int Turn)
        {
            myVillage = SetVillage;
            MyMelee = myVillage.MeleeUnits;
            MyRange = myVillage.RangeUnits;
            SetupAttack(Turn);
        }

        private void SetupAttack(int Turn)
        {
            Random rnd = new Random();
            int Max = (Turn / 5)+1;

            AttackMelee.SetInitDetails();
            AttackMelee.Name = "Slasher";
            AttackRange.SetInitDetails();
            AttackRange.Name = "Thrower";
            
            AttackMelee.Count = rnd.Next(1, Max);
        }
    }
}
