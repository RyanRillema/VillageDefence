using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VillageDefence.Models;
using VillageDefence.Models.Units;

namespace VillageDefence.Views
{
    public partial class BattleView : UserControl
    {
        public MainView myParent;
        public Battle myBattle;
        public int Turn = 0; //1-MyRange, 2-AttRange, 3-MyMelee, 4-AttMelee
        public Unit AttackUnit;
        public Unit DefendUnit;
        public int DamageTotal = 0;
        public BattleView(MainView SetParent)
        {
            InitializeComponent();
            myParent = SetParent;
            myBattle = new Battle();
            myBattle.SetupBattle(myParent.myGame.myVillage, myParent.myGame.Turn);
            NextTurn();
            Refresh();
            myParent.ShowHome(false);
            myParent.ShowNext(false);
        }
        public void NextTurn()
        {
            if (CheckEnd())
            {                
                return;
            }

            if (++Turn == 5)
            {
                // Reset turns
                Turn = 1;
            }

            if (CheckArmy())
            {
                OutputLabel.Content = AttackUnit.Name + " turn";
                if (Turn == 4)
                {
                    AttackerAttack();
                    Attack();
                }
            }
            else
            {
                NextTurn();
            }            
        }
        public void CloseButtonClicked(object source, RoutedEventArgs args)
        {
            myParent.ShowHome(true);
            myParent.LoadMainView();
        }
        public void ButtonClicked(object source, RoutedEventArgs args)
        {
            if (source.Equals(AttackMeleeButton))
            {
                DefendUnit = myBattle.AttackMelee;
            } else if (source.Equals(AttackRangeButton))
            {
                DefendUnit = myBattle.AttackRange;
            }
            Attack();
        }
        private void AttackerAttack()
        {
            if (myBattle.MyMelee.Count !=0)
            {
                DefendUnit = myBattle.MyMelee;
            }
            else
            {
                DefendUnit = myBattle.MyRange;
            }
        }
        private void Attack()
        {
            DamageTotal = AttackUnit.Count * AttackUnit.CombatStats.DamageValue;

            DefendUnit.DoDamage(DamageTotal);
            NextTurn();
            Refresh();
        }
        private bool CheckArmy()
        {
            switch (Turn)
            {
                case 1:
                    if (myBattle.MyRange.Count >0)
                    {
                        AttackUnit = myBattle.MyRange;
                        return true;
                    } else
                    {
                        return false;
                    }
                case 2:
                    if (myBattle.AttackRange.Count > 0)
                    {
                        AttackUnit = myBattle.AttackRange;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    if (myBattle.MyMelee.Count > 0)
                    {
                        AttackUnit = myBattle.MyMelee;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 4:
                    if (myBattle.AttackMelee.Count > 0)
                    {
                        AttackUnit = myBattle.AttackMelee;
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }
        private bool CheckEnd()
        {
            if (myBattle.AttackMelee.Count < 1)
            {
                if (myBattle.AttackRange.Count < 1)
                {
                    OutputLabel.Content = "You win";
                    myParent.ShowHome(true);
                    return true;
                }
            }
            else if (myBattle.MyMelee.Count < 1)
            {
                if (myBattle.MyRange.Count < 1)
                {
                    OutputLabel.Content = "You lose";
                    return true;
                }
            }
            return false;
        }
        public void Refresh()
        {
            AttackMeleeButton.Content = "Melee\nAttack: " + myBattle.AttackMelee.CombatStats.DamageValue
                + "\nDefence: " + myBattle.AttackMelee.CombatStats.ArmourValue
                + "\nCount: " + myBattle.AttackMelee.Count
                + "\nHealth: " + myBattle.AttackMelee.Health.CurrentHealth + " / "+ myBattle.AttackMelee.Health.TotalHealth;
            if (myBattle.AttackMelee.Count < 1)
            {
                AttackMeleeButton.IsEnabled = false;
            }
            AttackRangeButton.Content = "Range\nAttack: " + myBattle.AttackRange.CombatStats.DamageValue
                + "\nDefence: " + myBattle.AttackRange.CombatStats.ArmourValue
                + "\nCount: " + myBattle.AttackRange.Count
                + "\nHealth: " + myBattle.AttackRange.Health.CurrentHealth + " / " + myBattle.AttackRange.Health.TotalHealth;
            if (myBattle.AttackRange.Count < 1)
            {
                AttackRangeButton.IsEnabled = false;
            }

            MyMeleeButton.Content = "Melee\nAttack: " + myBattle.MyMelee.CombatStats.DamageValue
                + "\nDefence: " + myBattle.MyMelee.CombatStats.ArmourValue
                + "\nCount: " + myBattle.MyMelee.Count
                + "\nHealth: " + myBattle.MyMelee.Health.CurrentHealth + " / " + myBattle.MyMelee.Health.TotalHealth;
            if (myBattle.MyMelee.Count < 1)
            {
               MyMeleeButton.IsEnabled = false;
            }
            MyRangeButton.Content = "Range\nAttack: " + myBattle.MyRange.CombatStats.DamageValue
                + "\nDefence: " + myBattle.MyRange.CombatStats.ArmourValue
                + "\nCount: " + myBattle.MyRange.Count
                + "\nHealth: " + myBattle.MyRange.Health.CurrentHealth + " / " + myBattle.MyRange.Health.TotalHealth;
            if (myBattle.MyRange.Count < 1)
            {
                MyRangeButton.IsEnabled = false;
            }
        }

    }
}
