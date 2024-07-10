using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.Units;
using VillageDefence.Views;

namespace VillageDefence.Models
{
    public class Battle(BattleView SetParentBattleView)
    {
        public BattleView ParentBattleView = SetParentBattleView;
        public Village myVillage;
        public MeleeUnit AttackMelee = new MeleeUnit();
        public RangeUnit AttackRange = new RangeUnit();
        public MeleeUnit MyMelee;
        public RangeUnit MyRange;
        public int Turn = 0; //1-MyRange, 2-AttRange, 3-MyMelee, 4-AttMelee
        public Unit AttackUnit, DefendUnit;
        public int DamageTotal = 0;
        public String OutputA, OutputB, OutputC, OutputD, OutputE, OutputF;

        public void NextTurn()
        {
            while (!PlayNextTurn())
            {
                ParentBattleView.Refresh();
            }

            ParentBattleView.Refresh();
        }
        public bool PlayNextTurn()
        {
            if (CheckEnd())
            {
                EndBattle();
                return true;
            }

            if (++Turn == 5)
            {
                // Reset turns
                Turn = 1;
            }

            if (CheckArmy())
            {
                ParentBattleView.ClearButtonHighlight();
                AddOutput(AttackUnit.Name + " turn");
                if (Turn == 1)
                {
                    ParentBattleView.MyRangeButton.BorderThickness = Avalonia.Thickness.Parse("3");
                    return true;
                }
                if (Turn == 2)
                {
                    AttackerAttack();
                    Attack();
                    return false;
                }
                if (Turn == 3)
                {
                    ParentBattleView.MyMeleeButton.BorderThickness = Avalonia.Thickness.Parse("3");
                    return true;
                }
                if (Turn == 4)
                {
                    AttackerAttack();
                    Attack();
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void SetupBattle(Village SetVillage, int Turn)
        {
            myVillage = SetVillage;
            MyMelee = myVillage.MeleeUnits;
            MyRange = myVillage.RangeUnits;
            SetupAttack(Turn);
        }
        public void AttackerAttack()
        {
            //Find a unit for the attacker to attack
            if (MyMelee.Count > 0)
            {
                DefendUnit = MyMelee;
            }
            else if (MyRange.Count > 0)
            {
                DefendUnit = MyRange;
            } else
            {
                Debug.Assert(true,"Cant find unit to attack");
            }
        }
        public void Attack()
        {
            int DamageDone=0;
            DamageTotal = AttackUnit.Count * AttackUnit.CombatStats.DamageValue;

            if (DefendUnit.DoDamage(DamageTotal, ref DamageDone))
            {
                AddOutput(DefendUnit.Name + " was killed");
            }

            AddOutput(AttackUnit.Name + " hits " + DefendUnit.Name + " for " + DamageDone);

            ParentBattleView.Refresh();
        }
        public bool CheckArmy()
        {
            switch (Turn)
            {
                case 1:
                    if (MyRange.Count > 0)
                    {
                        AttackUnit = MyRange;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    if (AttackRange.Count > 0)
                    {
                        AttackUnit = AttackRange;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    if (MyMelee.Count > 0)
                    {
                        AttackUnit = MyMelee;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 4:
                    if (AttackMelee.Count > 0)
                    {
                        AttackUnit = AttackMelee;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
        public bool CheckEnd()
        {
            if (AttackMelee.Count < 1)
            {
                if (AttackRange.Count < 1)
                {
                    AddOutput("You win");
                    ParentBattleView.myParent.ShowHome(true);
                    return true;
                }
            }

            if (MyMelee.Count < 1)
            {
                if (MyRange.Count < 1)
                {
                    AddOutput("You lose");
                    return true;
                }
            }
            return false;
        }
        public void AddOutput(String NewOutput)
        {
            OutputF = OutputE;
            OutputE = OutputD;
            OutputD = OutputC;
            OutputC = OutputB;
            OutputB = OutputA;
            OutputA = NewOutput;
        }
        private void SetupAttack(int Turn)
        {
            Random rnd = new Random();
            int Max;
            int Min;

            AttackMelee.SetInitDetails();
            AttackMelee.Name = "Slasher";
            AttackRange.SetInitDetails();
            AttackRange.Name = "Thrower";
                        
            Max = (Turn / 5);
            Min = (Turn / 10)+1;
            //Max must be greater or equal to min
            Max = Math.Max(Max, Min);
            AttackMelee.Count = rnd.Next(Min, Max);

            Max = (Turn / 10);
            Min = (Turn / 30);
            Max = Math.Max(Max, Min);
            AttackRange.Count = rnd.Next(Min, Max);
        }
        private void EndBattle()
        {
            MyMelee.Health.CurrentHealth = MyMelee.Health.TotalHealth;
            MyRange.Health.CurrentHealth = MyRange.Health.TotalHealth;
            ParentBattleView.Refresh();
        }
    }
}
