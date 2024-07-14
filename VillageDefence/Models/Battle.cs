using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.BaseModels;
using VillageDefence.Models.Structures;
using VillageDefence.Models.Units;
using VillageDefence.Views;
using Avalonia.Animation;
using Avalonia.Controls;

namespace VillageDefence.Models
{
    public class Battle(BattleView SetParentBattleView)
    {
        public BattleView ParentBattleView = SetParentBattleView;
        public Village myVillage;
        public BaseModel AttackMelee = new MeleeUnit();
        public BaseModel AttackRange = new RangeUnit();
        public BaseModel MyMelee, MyRange, MyTowerA, MyTowerB, MyWallA, MyWallB;
        public int Turn = 0; // 1- MyTowerA, 2-MyTowerB, 3-MyRange, 4-AttRange, 5-MyMelee, 6-AttMelee
        public BaseModel AttackUnit, DefendUnit;
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

            if (++Turn == 7)
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
                    ParentBattleView.MyTowerAButton.BorderThickness = Avalonia.Thickness.Parse("3");
                    return true;
                }
                if (Turn == 2)
                {
                    ParentBattleView.MyTowerBButton.BorderThickness = Avalonia.Thickness.Parse("3");
                    return true;
                }
                if (Turn == 3)
                {
                    ParentBattleView.MyRangeButton.BorderThickness = Avalonia.Thickness.Parse("3");
                    return true;
                }
                if (Turn == 4)
                {
                    AttackerAttack();
                    return false;
                }
                if (Turn == 5)
                {
                    ParentBattleView.MyMeleeButton.BorderThickness = Avalonia.Thickness.Parse("3");
                    return true;
                }
                if (Turn == 6)
                {
                    AttackerAttack();
                    return false;
                }
                else
                {
                    Debug.Assert(false, "End of turns");
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
            MyTowerA = myVillage.TowerA;
            MyTowerB = myVillage.TowerB;
            SetupAttack(Turn);
        }
        public void AttackerAttack()
        {
            Button DefendButton = null;
            //Find a unit for the attacker to attack
            while (DefendButton == null)
            {
                if ((MyTowerA.Count > 0) && (SpinGenerator.SpinAttackerAttack(2)))
                {
                    DefendUnit = MyTowerA;
                    DefendButton = ParentBattleView.MyTowerAButton;
                }
                else if ((MyTowerB.Count > 0) && (SpinGenerator.SpinAttackerAttack(2)))
                {
                    DefendUnit = MyTowerB;
                    DefendButton = ParentBattleView.MyTowerBButton;
                }
                else if((MyMelee.Count > 0) && (SpinGenerator.SpinAttackerAttack(3)))
                {
                    DefendUnit = MyMelee;
                    DefendButton = ParentBattleView.MyMeleeButton;
                }
                else if ((MyRange.Count > 0) && (SpinGenerator.SpinAttackerAttack(5)))
                {
                    DefendUnit = MyRange;
                    DefendButton = ParentBattleView.MyRangeButton;
                }
            }            

            Attack(DefendButton);
        }
        public void Attack(Button DefendButton)
        {
            int DamageDone=0;
            bool UnitKilled = false;
            DamageTotal = AttackUnit.Count * AttackUnit.CombatStats.DamageValue;

            if (DefendUnit.DoDamage(DamageTotal, ref DamageDone))
            {
                UnitKilled = true;                
            }

            AddOutput(AttackUnit.Name + " hits " + DefendUnit.Name + " for " + DamageDone);

            if (UnitKilled)
            {
                AddOutput(DefendUnit.Name + " was killed");
                ParentBattleView.KillAnimation(DefendButton);
            }
            else
            {
                ParentBattleView.AttackAnimation(DefendButton);
            }

            ParentBattleView.Refresh();
        }
        public bool CheckArmy()
        {
            switch (Turn)
            {
                case 1:
                    return CheckArmy(MyTowerA);
                case 2:
                    return CheckArmy(MyTowerB);
                case 3:
                    return CheckArmy(MyRange);
                case 4:
                    return CheckArmy(AttackRange);
                case 5:
                    return CheckArmy(MyMelee);
                case 6:
                    return CheckArmy(AttackMelee);
                default:
                    return false;
            }
        }
        private bool CheckArmy(BaseModel CheckArmy)
        {
            if (CheckArmy.Count > 0)
            {
                AttackUnit = CheckArmy;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEnd()
        {
            if ((AttackMelee.Count < 1) && (AttackRange.Count < 1))
            {
                AddOutput("You win");
                ParentBattleView.myParent.ShowHome(true);
                return true;
            }

            if ((MyMelee.Count < 1) && (MyRange.Count < 1) && (MyTowerA.Count < 1) && (MyTowerB.Count < 1))
            //&& (MyWallA.Count < 1) && (MyWallB.Count < 1)
            {
                AddOutput("You lose");
                return true;
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
            VillageDefence.SpinGenerator.SetupAttack(Turn, AttackMelee, AttackRange);
        }
        private void EndBattle()
        {
            //MyMelee.Health.CurrentHealth = MyMelee.Health.TotalHealth;
            //MyRange.Health.CurrentHealth = MyRange.Health.TotalHealth;
            ParentBattleView.ClearButtonHighlight();
            ParentBattleView.Refresh();
        }
    }
}
